using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipamentSlot
{
    Weapon, Armor, Acessory
}

[System.Serializable]
public struct Equipment 
{
    public string name;
    public int cost;
    public EquipamentSlot slot;

    public int strengthBonus;
    public int dexterityBonus;
    public int vitalityBonus;
    public int magicBonus;
    public int spiritBonus;
    public int luckBonus;


    public string specialSkill;
}
