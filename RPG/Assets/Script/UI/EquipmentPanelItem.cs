using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanelItem : MonoBehaviour
{
    public int id = 0;
    public Text name;
    public Button button;

    public void Initialize(int id)
    {
        this.id = id;
        Equipment equipment = GameManager.Instance.equipamentOnSale[id];

        /*slot.text = "Type: " + equipment.slot;
        strengthBonus.text = "Strength Bonus: " + equipment.strengthBonus;
        dexterityBonus.text = "Dexterity Bonus: " + equipment.dexterityBonus;
        vitalityBonus.text = "Vitality Bonus: " + equipment.vitalityBonus;
        magicBonus.text = "Magic Bonus" + equipment.magicBonus;
        spiritBonus.text = "Spirit Bonus: " + equipment.spiritBonus;
        luckBonus.text = "Luck Bonus: " + equipment.luckBonus;*/
        #region SHIT
        string details = equipment.name + "\r\n(";

        if (equipment.strengthBonus > 0)
        {
            details += "+" + equipment.strengthBonus + "STR ";
        }
        else if (equipment.strengthBonus < 0)
        {
            details += equipment.strengthBonus + "STR ";
        }

        if (equipment.dexterityBonus > 0)
        {
            details += "+" + equipment.dexterityBonus + "DEX ";
        }

        else if (equipment.dexterityBonus < 0)
        {
            details += equipment.dexterityBonus + "DEX ";
        }

        if (equipment.vitalityBonus > 0)
        {
            details += "+" + equipment.vitalityBonus + "VIT ";
        }
        else if (equipment.vitalityBonus < 0)
        {
            details += equipment.vitalityBonus + "VIT ";
        }

        if (equipment.magicBonus > 0)
        {
            details += "+" + equipment.magicBonus + "MAG ";
        }
        else if (equipment.magicBonus < 0)
        {
            details += equipment.magicBonus + "MAG ";
        }

        if (equipment.spiritBonus > 0)
        {
            details += "+" + equipment.spiritBonus + "SPR ";
        }
        else if (equipment.spiritBonus < 0)
        {
            details += equipment.spiritBonus + "SPR ";
        }

        if (equipment.luckBonus > 0)
        {
            details += "+" + equipment.luckBonus + "LCK ";
        }
        else if (equipment.luckBonus < 0)
        {
            details += equipment.luckBonus + "LCK ";
        }
        details += ")";
        #endregion
        name.text = details;

        button.onClick.AddListener(() =>
        {
            //Equip(this.id);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Status");
        });
    }
}

