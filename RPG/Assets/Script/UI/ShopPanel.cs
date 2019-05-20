using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public GameObject shopPanelItemPrefab;
    public Transform content;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<GameManager.Instance.equipamentOnSale.Count; i++)
        {
            GameObject shopPanelItemObject = Instantiate(shopPanelItemPrefab, content);
            ShopPanelItem shopPanelItemScript = shopPanelItemObject.GetComponent<ShopPanelItem>();
            shopPanelItemScript.Initialize(i);
        }
    }
}
