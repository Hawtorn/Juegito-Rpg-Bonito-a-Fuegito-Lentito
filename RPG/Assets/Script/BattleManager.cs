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
            //Turno jugador 1 
            yield return playerBattler.DoTurn();
            //Comprobar victoria
            
            // Si gana un jugador battleEnded = true 
            // Si no ha acabado la batalla -> Turno jugardor 2 
            yield return playerBattler.DoTurn();
            yield return null; //esperar al siguiente fotograma
        }
    }
    
    bool HasABattlerDied()
    {
        return playerBattler.hp <= 0 || enemyBattler.hp <= 0;
    }
}
