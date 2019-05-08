using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlerInfoPanel : MonoBehaviour
{
    public Battler battler;
    public RectTransform atbBar;
    public RectTransform hpBar;
    public RectTransform mpBar;

    public Text nameText;
    public Text hpText;
    public Text mpText;

    void UpdateInfo()
    {
        
        atbBar.transform.localScale = new Vector3(battler.atbBar, 1f, 1f);
        hpBar.transform.localScale = new Vector3((float)battler.hp / (float)battler.maxHP, 1f, 1f);
        mpBar.transform.localScale = new Vector3((float)battler.mp / (float)battler.maxMP, 1f, 1f);

        nameText.text = battler.battlerName;
        hpText.text = "HP " + battler.hp + "/" + battler.maxHP;
        mpText.text = "MP " + battler.mp + "/" + battler.maxMP;
    }

    // Update is called once per frame
    void Start()
    {
        if(battler != null)
        {
            UpdateInfo();
        }
    }
    void Update()
    {
        if (battler != null)
        {
            UpdateInfo();
        }
    }
}
