using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    CharacterStats stats;
    public int hp;
    public int maxHP;
    public int mp;
    public int maxMP;

    public void Initialize(CharacterStats stats)
    {
        this.stats = stats;
        maxHP = Formulas.GetMaxHP(stats);
        maxMP = Formulas.GetMaxMP(stats);
        hp = maxHP;
        mp = maxMP;

    }

    public IEnumerator DoTurn()
    {
        Debug.Log("Start of" + gameObject.name + "´s turn");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("End of" + gameObject.name + "´s turn");

    }
}
