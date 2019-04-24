using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public Battler playerBattler;
    public Battler enemyBattler;

    void Awake()
    {
        Instance = this;
        playerBattler.Initialize(new CharacterStats());
        enemyBattler.Initialize(new CharacterStats());
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
            if (playerBattler.atbBar >= 1.0f)
            {
                playerBattler.atbBar = 0f;
                yield return playerBattler.DoTurn(enemyBattler);
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
        enemyBattler.atbBar += enemyBattler.stats.dexterity * dexIncrement;



    }

    bool HasABattlerDied()
    {
        return playerBattler.hp <= 0 || enemyBattler.hp <= 0;
    }
}
