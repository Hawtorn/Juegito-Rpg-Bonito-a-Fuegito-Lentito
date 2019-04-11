using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formulas 
{
    public static int GetMaxHP(CharacterStats stats)
    {
        return Mathf.FloorToInt(10.0f * Mathf.Sqrt(stats.level) * stats.constitution);
    }


    public static int GetMaxMP(CharacterStats stats)
    {
        return Mathf.FloorToInt(Mathf.Sqrt(stats.level) * (stats.intelligence + stats.wisdom));
    }


    public static float GetPhysicalAttackPower(CharacterStats stats)
    {
        return Mathf.Pow(stats.strength, 2.0f);
    }


    public static float GetPhysicalDefensePower(CharacterStats stats)
    {
        return Mathf.Log(stats.constitution);
    }


    public static float GetMagicalAttackPower(CharacterStats stats)
    {
        return Mathf.Pow(stats.intelligence, 2.0f);
    }

    public static float GetMagicalDefensePower(CharacterStats stats)
    {
        return Mathf.Log(stats.wisdom);
    }

    public static int GetPhysicalDamage(CharacterStats attacker, CharacterStats defender)
    {
        float baseDamage = 5.0f * GetPhysicalAttackPower(attacker) / GetPhysicalDefensePower(defender);

        if (baseDamage < 1.0f) baseDamage = 1.0f;
        return Mathf.FloorToInt(baseDamage);
    }


    public static int GetMagicalDamage(CharacterStats attacker, CharacterStats defender)
    {
        float baseDamage = 5.0f * GetMagicalAttackPower(attacker) / GetMagicalDefensePower(defender);

        if (baseDamage < 1.0f) baseDamage = 1.0f;
        return Mathf.FloorToInt(baseDamage);
    }

    public static int GetExperienceForNextLevel(CharacterStats stats)
    {
        return 100;
    }

    public static int GetExperienceFromKill(CharacterStats killer, CharacterStats killed)
    {
        float baseExp = 10.0f * (1.0f + ((killed.level - killer.level) * 0.1f));
        if (baseExp < 1f) baseExp = 1f;
        return Mathf.RoundToInt(baseExp);
    }
}
