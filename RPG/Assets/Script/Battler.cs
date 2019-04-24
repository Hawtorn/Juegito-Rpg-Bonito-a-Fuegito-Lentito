using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    public CharacterStats stats;
    public int hp;
    public int maxHP;
    public int mp;
    public int maxMP;

    public float atbBar;

    const float ATTACK_DISTANCE = 1.0f;
    const float MOVEMENT_SPEED = 10.0f;

    public void Initialize(CharacterStats stats)
    {
        this.stats = stats;
        maxHP = Formulas.GetMaxHP(stats);
        maxMP = Formulas.GetMaxMP(stats);
        hp = maxHP;
        mp = maxMP;

        // DEBUG
        this.stats.dexterity = Random.Range(10, 100);
        Debug.Log(gameObject.name + "'s dexterity is " + this.stats.dexterity);
        // END DEBUG

    }

    public IEnumerator DoTurn(Battler target)
    {
        Vector3 startPosition = this.transform.position;

        while (Vector3.Distance(this.transform.position, target.transform.position) > ATTACK_DISTANCE)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                target.transform.position, MOVEMENT_SPEED * Time.deltaTime);
            yield return null;
        }

        target.ReceiveDamage(Formulas.GetPhysicalDamage(1.0f, this.stats, null, target.stats, null));

        while (Vector3.Distance(this.transform.position, startPosition) > 0.01f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                startPosition, MOVEMENT_SPEED * Time.deltaTime);
            yield return null;
        }
        
        /* Debug.Log("Start of" + gameObject.name + "´s turn");
         yield return new WaitForSeconds(2.0f);
         Debug.Log("End of" + gameObject.name + "´s turn");
         */
    }

    public void ReceiveDamage(int damage)
    {
        this.hp -= damage;
    }
}
