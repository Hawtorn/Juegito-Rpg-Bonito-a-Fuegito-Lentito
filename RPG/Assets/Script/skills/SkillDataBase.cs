using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillDataBase
{
    static Dictionary<string, BaseSkill> skills = new Dictionary<string, BaseSkill>();  


    static SkillDataBase()
    {
        skills.Add("Attack", new BasicPhysicalAttackSkill());
        skills.Add("Fire", new FireSkill());
    }


    public static BaseSkill GetSkill(string skillName)
    {
        return skills[skillName];
    }
}
