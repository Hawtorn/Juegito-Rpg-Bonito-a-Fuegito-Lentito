using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{
    public Image expBar;
    public Text expBarText;
    public Text level;
    public Text gold;
    public Text upgradePoints;
    public Text streght;
    public Text dexterity;
    public Text vitality;
    public Text magic;
    public Text spirit;
    public Text luck;

    void Update()
    {
        level.text = "Level " + GameManager.Instance.playerCharactersStats.level;
        gold.text = "Gold: " + GameManager.Instance.gold;
        float barPercent = (float)GameManager.Instance.playerExperience / (float)Formulas.GetExperienceToNextLevel(GameManager.Instance.playerCharactersStats);
        expBar.transform.localScale = new Vector3(barPercent, 1f, 1f);
        expBarText.text = GameManager.Instance.playerExperience + "/" + Formulas.GetExperienceToNextLevel(GameManager.Instance.playerCharactersStats);  
        streght.text = "Strength: " + GameManager.Instance.playerCharactersStats.strength + "      ( "+ (GameManager.Instance.weapon.strengthBonus + GameManager.Instance.armor.strengthBonus + GameManager.Instance.accesory.strengthBonus) + " ) " ;
        dexterity.text = "Dexterity: " + GameManager.Instance.playerCharactersStats.dexterity + "      ( " + (GameManager.Instance.weapon.dexterityBonus + GameManager.Instance.armor.dexterityBonus + GameManager.Instance.accesory.dexterityBonus) + " ) ";
        vitality.text = "Vitality: " + GameManager.Instance.playerCharactersStats.vitality + "      ( " + (GameManager.Instance.weapon.vitalityBonus + GameManager.Instance.armor.vitalityBonus + GameManager.Instance.accesory.vitalityBonus) + " ) ";
        magic.text = "Magic: " + GameManager.Instance.playerCharactersStats.magic + "      ( " + (GameManager.Instance.weapon.magicBonus + GameManager.Instance.armor.magicBonus + GameManager.Instance.accesory.magicBonus) + " ) ";
        spirit.text = "Spirit: " + GameManager.Instance.playerCharactersStats.spirit + "      ( " + (GameManager.Instance.weapon.spiritBonus + GameManager.Instance.armor.spiritBonus + GameManager.Instance.accesory.spiritBonus) + " ) ";
        luck.text = "Luck: " + GameManager.Instance.playerCharactersStats.luck + "      ( " + (GameManager.Instance.weapon.luckBonus + GameManager.Instance.armor.luckBonus + GameManager.Instance.accesory.luckBonus) + " ) ";
        upgradePoints.text = "Upgrade Points: " + GameManager.Instance.upgradePoints;

        if (Time.timeSinceLevelLoad >= 2.0f)
        {
            if(GameManager.Instance.gainedExperience > 0)
            {
                GameManager.Instance.gainedExperience--;
                GameManager.Instance.playerExperience++;
                if(GameManager.Instance.playerExperience >= Formulas.GetExperienceToNextLevel(GameManager.Instance.playerCharactersStats))
                {

                    LevelUp();
                }
            }
        }



    }
    void LevelUp()
    {
        GameManager.Instance.playerExperience = 0;
        GameManager.Instance.playerCharactersStats.level++;
        GameManager.Instance.upgradePoints += Formulas.GetUpgradePointsOnLevelUp();

        if(GameManager.Instance.playerCharactersStats.level >= 2)
        {
            if (!GameManager.Instance.skills.Contains("Fire"))
            {
                GameManager.Instance.skills.Add("Fire");
            }
        }

    }

    public void UpgradeStrength()
    {
        if(GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.strength++;
        }
    }
    public void UpgradeDexterity()
    {
        if (GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.dexterity++;
        }
    }
    public void UpgradeVitality()
    {
        if (GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.vitality++;
        }
    }
    public void UpgradeMagic()
    {
        if (GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.magic++;
        }
    }
    public void UpgradeSpirit()
    {
        if (GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.spirit++;
        }
    }
    public void UpgradeLuck()
    {
        if (GameManager.Instance.upgradePoints > 0)
        {
            GameManager.Instance.upgradePoints--;
            GameManager.Instance.playerCharactersStats.luck++;
        }
    }
}
