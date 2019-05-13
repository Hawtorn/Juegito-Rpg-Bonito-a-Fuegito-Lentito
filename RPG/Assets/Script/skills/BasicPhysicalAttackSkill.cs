using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPhysicalAttackSkill : BaseSkill
{
    const float ATTACK_DISTANCE = 1.0f;
    const float MOVEMENT_SPEED = 10.0f;
    const float SKILL_POWER = 1.0f;

    public override IEnumerator ExecuteSkill(Battler user, Battler[] targets)
    {

        Vector3 startPosition = user.transform.position;

        while (Vector3.Distance(user.transform.position, targets[0].transform.position) > ATTACK_DISTANCE)
        {
            user.transform.position = Vector3.MoveTowards(user.transform.position,
                targets[0].transform.position, MOVEMENT_SPEED * Time.deltaTime);
            yield return null;
        }


        if(Formulas.DoesAttackHit(user.stats, targets[0].stats))
        {
            int damage = Formulas.GetPhysicalDamage(SKILL_POWER, user.stats,targets[0].stats);
            if(Formulas.DoesAttackCrit(user.stats, targets[0].stats))
            {
                damage *= 2;
            }
            targets[0].ReceiveDamage(damage);
        }
        else
        {
            targets[0].ShowDamageIndicator("Miss", Color.white);
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
        return 0;
    }

    public override string GetName()
    {
        return "Attack";
    }
}
