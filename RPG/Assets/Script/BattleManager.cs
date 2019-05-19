using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public Battler playerBattler;
    public Battler enemyBattler;
    public GameObject skillButtonPrefab;
    public GameObject commands;

    public BattlerInfoPanel playerPanel;
    public BattlerInfoPanel enemyPanel;

    BaseSkill playerSkillToUse;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameObject playerObject = Instantiate(GameManager.Instance.battlePlayerPrefab, new Vector3(-7f, 0f, 0f), Quaternion.identity);

        GameObject enemyObject = Instantiate(GameManager.Instance.battleEnemyPrefab, new Vector3(7f, 0f, 0f), Quaternion.identity);

        playerBattler = playerObject.GetComponent<Battler>();
        enemyBattler = enemyObject.GetComponent<Battler>();

        playerPanel.battler = playerBattler;
        enemyPanel.battler = enemyBattler;

        playerBattler.stats = GameManager.Instance.playerCharactersStats;

        //Strength
        playerBattler.stats.strength += GameManager.Instance.weapon.strengthBonus;
        playerBattler.stats.strength += GameManager.Instance.armor.strengthBonus;
        playerBattler.stats.strength += GameManager.Instance.accesory.strengthBonus;
        //Dexterity
        playerBattler.stats.dexterity += GameManager.Instance.weapon.dexterityBonus;
        playerBattler.stats.dexterity += GameManager.Instance.armor.dexterityBonus;
        playerBattler.stats.dexterity += GameManager.Instance.accesory.dexterityBonus;
        //Vitality
        playerBattler.stats.vitality += GameManager.Instance.weapon.vitalityBonus;
        playerBattler.stats.vitality += GameManager.Instance.armor.vitalityBonus;
        playerBattler.stats.vitality += GameManager.Instance.accesory.vitalityBonus;
        //Magic
        playerBattler.stats.magic += GameManager.Instance.weapon.magicBonus;
        playerBattler.stats.magic += GameManager.Instance.armor.magicBonus;
        playerBattler.stats.magic += GameManager.Instance.accesory.magicBonus;
        //Spirit
        playerBattler.stats.spirit += GameManager.Instance.weapon.spiritBonus;
        playerBattler.stats.spirit += GameManager.Instance.armor.spiritBonus;
        playerBattler.stats.spirit += GameManager.Instance.accesory.spiritBonus;
        //Luck
        playerBattler.stats.luck += GameManager.Instance.weapon.luckBonus;
        playerBattler.stats.luck += GameManager.Instance.armor.luckBonus;
        playerBattler.stats.luck += GameManager.Instance.accesory.luckBonus;

        //playerBattler.skillNames = GameManager.Instance.skills.ToArray();
        List<string> skillsNames = new List<string>(GameManager.Instance.skills);

        if (!string.IsNullOrEmpty(GameManager.Instance.weapon.specialSkill))
        {
            skillsNames.Add(GameManager.Instance.weapon.specialSkill);
        }

        if (!string.IsNullOrEmpty(GameManager.Instance.armor.specialSkill))
        {
            skillsNames.Add(GameManager.Instance.armor.specialSkill);
        }
        if (!string.IsNullOrEmpty(GameManager.Instance.accesory.specialSkill))
        {
            skillsNames.Add(GameManager.Instance.accesory.specialSkill);
        }

        playerBattler.Initialize();
        enemyBattler.Initialize();
        
        for (int i = 0; i < playerBattler.battlerSkills.Length; i++)
        {
            GameObject buttonObject = GameObject.Instantiate(skillButtonPrefab, commands.transform);
            Button button = buttonObject.GetComponent<Button>();

            BaseSkill skill = playerBattler.battlerSkills[i];
            string text = skill.GetName() + " MP: " + skill.GetMPCost();
            buttonObject.GetComponentInChildren<Text>().text = text;

            button.onClick.AddListener(() => { playerSkillToUse = skill; });
        }
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
                if(playerBattler.hp > 0)
                {
                    GameManager.Instance.gainedExperience += Formulas.GetExperienceEarned(playerBattler.stats, enemyBattler.stats);
                    GameManager.Instance.gold += Formulas.GetGold(playerBattler.stats, enemyBattler.stats);
                }
               
                SceneManager.LoadScene("Status");
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
