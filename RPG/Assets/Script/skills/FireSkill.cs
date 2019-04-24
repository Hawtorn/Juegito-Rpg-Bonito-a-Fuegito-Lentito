using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : BaseSkill
{
    const float ATTACK_DISTANCE = 10.0f;
    const float MOVEMENT_SPEED = 10.0f;
    const float SKILL_POWER = 1f;

    public override IEnumerator ExecuteSkill(Battler user, Battler[] targets)
    {

        Vector3 startPosition = user.transform.position;

        while (Vector3.Distance(user.transform.position, targets[0].transform.position) > ATTACK_DISTANCE)
        {
            user.transform.position = Vector3.MoveTowards(user.transform.position,
                targets[0].transform.position, MOVEMENT_SPEED * Time.deltaTime);
            yield return null;
        }


        if(Formulas.DoesMagicAttackHit(user.stats, null, targets[0].stats, null))
        {
            int damage = Formulas.GetMagicDamage(SKILL_POWER, user.stats, null, targets[0].stats, null);
           /* if(Formulas.DoesAttackCrit(user.stats, null, targets[0].stats, null))
            {
                damage *= 2;
            }*/
            targets[0].ReceiveDamage(damage);
        }
      

        while (Vector3.Distance(user.transform.position, startPosition) > 0.01f)
        {
            user.transform.position = Vector3.MoveTowards(user.transform.position,
                startPosition, MOVEMENT_SPEED * Time.deltaTime);
            yield return null;
        }
    }

    public override int GetMPCost()
    {
        return 5;
    }
}
