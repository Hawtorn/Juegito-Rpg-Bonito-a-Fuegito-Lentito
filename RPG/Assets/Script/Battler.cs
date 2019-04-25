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

    public GameObject damageIndacatorPrefab;

    const float ATTACK_DISTANCE = 1.0f;
    const float MOVEMENT_SPEED = 10.0f;

    public BaseSkill[] battlerSkills = new BaseSkill[]
    {
        new BasicPhysicalAttackSkill(),
        new FireSkill()
    };

    public void Initialize(CharacterStats stats)
    {
        this.stats = stats;
        maxHP = Formulas.GetMaxHP(stats);
        maxMP = Formulas.GetMaxMP(stats);
        hp = maxHP;
        mp = maxMP;

        

    }

    public IEnumerator DoTurn(Battler target)
    {
        BaseSkill chosenSkill = battlerSkills[Random.Range(0, battlerSkills.Length)];
        yield return ExecuteSkill(chosenSkill, target);
    }

    public IEnumerator ExecuteSkill(BaseSkill skill, Battler target)
    {
        if (mp >= skill.GetMPCost())
        {
            mp -= skill.GetMPCost();
            yield return skill.ExecuteSkill(this, new Battler[] { target });
        }
        else
        {
            this.ShowDamageIndicator("No MP!!!!", Color.black);
        }
    }

    public void ReceiveDamage(int damage)
    {
        this.hp -= damage;
        ShowDamageIndicator(damage.ToString(), Color.white);
        if(this.hp < 0)
        {
            this.hp = 0;
        }
    }

    public void ShowDamageIndicator(string text, Color color)
    {
        GameObject textObject = GameObject.Instantiate(damageIndacatorPrefab, this.transform);
        textObject.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
        textObject.GetComponent<TextMesh>().text = text;
        textObject.GetComponent<TextMesh>().color = color;
    }
}
