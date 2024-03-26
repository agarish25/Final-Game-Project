using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HotbarSelector : MonoBehaviour
{
    [SerializeField]
    KeyCode a;
    [SerializeField]
    KeyCode b;
    [SerializeField]
    KeyCode c;
    [SerializeField]
    KeyCode d;
    [SerializeField]
    InventoryItemData InventoryItemData;

    int i = 0;

    // Update is called once per frame
    void Update()   
    {
        Debug.Log(InventoryItemData.equippedData[i]);
        Debug.Log("g: " + InventoryItemData.grapplerActive + " s: " + InventoryItemData.spearActive + " d: " + InventoryItemData.doubleJumpActive);
        if (InventoryItemData.equippedData[i] == 2)
         {
             InventoryItemData.dashActive = 3;
             InventoryItemData.spearActive = 2;
             InventoryItemData.grapplerActive = 2;
         }
         else if (InventoryItemData.equippedData[i] == 5)
         {
             InventoryItemData.dashActive = 2;
             InventoryItemData.spearActive = 3;
             InventoryItemData.grapplerActive = 2;
         }
         else if (InventoryItemData.equippedData[i] == 4)
         {
             InventoryItemData.dashActive = 2;
             InventoryItemData.spearActive = 2;
             InventoryItemData.grapplerActive = 3;
         }
        else
        {
            if (InventoryItemData.dashActive == 3)
            {
                InventoryItemData.dashActive = 2;
            }
            if (InventoryItemData.spearActive == 3)
            {
                InventoryItemData.spearActive = 2;
            }
            if (InventoryItemData.spearActive == 3)
            {
                InventoryItemData.spearActive = 2;
            }
        }
        if (Input.GetKeyDown(a))
        {
            i = 0;
        }
        else if (Input.GetKeyDown(b))
        {
            i = 1;
        }
        else if (Input.GetKeyDown(c))
        {
            i = 2;
        }
        else if (Input.GetKeyDown(d))
        {
            i = 3;
        }
        transform.localPosition = new Vector2(-90 + 60 * i, -120);
    }
}
