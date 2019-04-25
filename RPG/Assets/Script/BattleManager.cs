using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public Battler playerBattler;
    public Battler enemyBattler;
    public GameObject skillButtonPrefab;
    public GameObject commands;

    BaseSkill playerSkillToUse;

    void Awake()
    {
        Instance = this;
        playerBattler.Initialize(new CharacterStats());
        enemyBattler.Initialize(new CharacterStats());

        for(int i=0; i<playerBattler.battlerSkills.Length; i++)
        {
            GameObject buttonObject = GameObject.Instantiate(skillButtonPrefab, commands.transform);
            Button button = buttonObject.GetComponent<Button>();

            BaseSkill skill = playerBattler.battlerSkills[i];
            string text = skill.GetName() + " MP: " + skill.GetMPCost();
            buttonObject.GetComponentInChildren<Text>().text = text;

            button.onClick.AddListener(() => { playerSkillToUse = skill; });
        }
    }
    void Start()
    {
        StartCoroutine(BattleCoroutine());
    }

    IEnumerator BattleCoroutine()
    {
        bool battleEnded = false;
        while (!battleEnded)
        {
            UpdateATB();
            commands.SetActive(playerBattler.atbBar >= 1.0f);
            if (playerSkillToUse != null)
            {
                playerBattler.atbBar = 0f;
                yield return playerBattler.ExecuteSkill(playerSkillToUse, enemyBattler);
                playerSkillToUse = null;
            }

            else if (enemyBattler.atbBar >= 1.0f)
            {
                enemyBattler.atbBar = 0f;
                yield return enemyBattler.DoTurn(playerBattler);
            }

            if (HasABattlerDied())
            {
                // Si gana un jugador battleEnded = true
                battleEnded = true;
            }
            yield return null; // Esperar al siguiente fotograma

        }
    }

    void UpdateATB()
    {
        //int minDex = Mathf.Min(playerBattler.stats.dexterity, enemyBattler.stats.dexterity);
        int maxDex = Mathf.Max(playerBattler.stats.dexterity, enemyBattler.stats.dexterity);
        float dexIncrement = Time.deltaTime * 0.25f / maxDex;
        playerBattler.atbBar += playerBattler.stats.dexterity * dexIncrement;
        
        if(playerBattler.atbBar > 1.0f)
        {
            playerBattler.atbBar = 1.0f;
        }
        enemyBattler.atbBar += enemyBattler.stats.dexterity * dexIncrement;
        if(enemyBattler.atbBar > 1.0f)
        {
            enemyBattler.atbBar = 1.0f;
        }


    }

    bool HasABattlerDied()
    {
        return playerBattler.hp <= 0 || enemyBattler.hp <= 0;
    }
}
