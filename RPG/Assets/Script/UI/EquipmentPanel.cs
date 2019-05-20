using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{

    public GameObject equipmentPanelItemPrefab;
    public Transform content;


    void Start()
    {
        for (int i = 0; i < GameManager.Instance.equipamentOnSale.Count; i++)
        {
            GameObject equipmentPanelItemObject = Instantiate(equipmentPanelItemPrefab, content);
            EquipmentPanelItem equipmentPanelItemScript = equipmentPanelItemObject.GetComponent<EquipmentPanelItem>();
            equipmentPanelItemScript.Initialize(i);
        }
    }
}
