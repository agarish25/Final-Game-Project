using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHG : MonoBehaviour
{

    public GameObject Inventory;
    public InventoryItemData InventoryItemData;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            InventoryItemData.healthGemActive = 1;
            Destroy(gameObject);
        }
    }
}
