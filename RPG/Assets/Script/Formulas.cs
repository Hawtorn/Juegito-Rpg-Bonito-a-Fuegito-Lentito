using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formulas
{
    #region DerivedStats
    public static float GetAttack(CharacterStats stats, Equipment equipment)
    {
        return stats.strength;
    }

    public static float GetAttackChance(CharacterStats stats, Equipment equipment)
    {
        return 80f;
    }

    public static float GetDefense(CharacterStats stats, Equipment equipment)
    {
        return stats.vitality;
    }
    public static float GetDefenseChance(CharacterStats stats, Equipment equipment)
    {
        return stats.dexterity * 0.25f;
    }
    public static float GetMagicAttack(CharacterStats stats, Equipment equipment)
    {
        return stats.magic;
    }
    public static float GetMagicDefense(CharacterStats stats, Equipment equipment)
    {
        return stats.spirit;
    }
    public static float GetMagicDefenseChance(CharacterStats stats, Equipment equipment)
    {
        return 0f;
    }
    #endregion

    public static bool DoesAttackHit(CharacterStats attackerStats, Equipment attackerEquipment, CharacterStats defenderStats, Equipment defenderEquipment)
    {
        float attDex = attackerStats.dexterity;
        float attAtC = GetAttackChance(attackerStats, attackerEquipment);
        float attDfC = GetDefenseChance(attackerStats, attackerEquipment);
        float defDfC = GetDefenseChance(defenderStats, defenderEquipment);


        float hitChance = attDex * 0.25f + attAtC + attDfC - defDfC;

        if (hitChance < 1.0f)
        {
            hitChance = 1.0f;
        }

        //Luck Hit
        if (Random.Range(0, 100) < attackerStats.luck * 0.25f)
        {
            hitChance = 255.0f;
        }
        //Luck Evade (solo cuando el ataque no es un luck hit)
        else if (Random.Range(0, 100) < defenderStats.luck * 0.25f)
        {
            hitChance = 0f;
        }

        return Random.Range(0.0f, 100.0f) < hitChance;
    }

    public static bool DoesMagicAttackHit(CharacterStats attackerStats, Equipment attackerEquipment, CharacterStats defenderStats, Equipment defenderEquipment)
    {
        return true;
    }

    public static bool DoesAttackCrit(CharacterStats attackerStats, Equipment attackerEquipment, CharacterStats defenderStats, Equipment defenderEquipment)
    {
        float critChance = (attackerStats.luck + attackerStats.level - defenderStats.level) * 0.25f; 

            return Random.Range(0.0f, 100.0f) < critChance;
    }

    public static int GetPhysicalDamage(float power, CharacterStats attackerStats, Equipment attackerEquipment, CharacterStats defenderStats, Equipment defenderEquipment)
    {
        float attack = GetAttack(attackerStats, attackerEquipment);
        float defense = GetDefense(defenderStats, defenderEquipment);
        float baseDamage = attack + ((attack + attackerStats.level) / 32) + ((attack * attackerStats.level) / 32);
        float damage = ((power * 4.0f * (512 - defense) * baseDamage) / (16 * 512));
        return Mathf.CeilToInt(damage * Random.Range(0.9f, 1.1f));
    }

    public static int GetMagicDamage(float power, CharacterStats attackerStats, Equipment attackerEquipment, CharacterStats defenderStats, Equipment defenderEquipment)
    {
        float mAttack = GetMagicAttack(attackerStats, attackerEquipment);
        float mDefense = GetMagicDefense(attackerStats, attackerEquipment);
        float baseDamage = 6 * (mAttack + attackerStats.level);
        float damage = ((power * 2.0f * (512 - mDefense) * baseDamage) / (16 * 512));
        return Mathf.CeilToInt(damage * Random.Range(0.9f, 1.1f));

    }

    public static int GetCuredDamage(float power, CharacterStats attackerStats, Equipment attackerEquipment)
    {
        float mAttack = GetMagicAttack(attackerStats, attackerEquipment);
        float baseDamage = 6 * (mAttack + attackerStats.level);
        float damage = baseDamage + 22 * power * 16.0f;
        return Mathf.CeilToInt(damage * Random.Range(0.9f, 1.1f));
    }

    public static int GetMaxHP(CharacterStats stats)
    {
        return Mathf.CeilToInt(Mathf.Pow(stats.level, 0.9f) * 50.0f * Mathf.Log10(stats.vitality * 20 + 1) * 0.75f);

    }
    public static int GetMaxMP(CharacterStats stats)
    {
        return Mathf.CeilToInt(Mathf.Pow(stats.level, 0.9f) * 5.0f * Mathf.Log10(stats.magic * 20 + 1) * 0.75f);

    }
}

