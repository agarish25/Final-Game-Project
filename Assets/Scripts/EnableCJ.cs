using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCJ : MonoBehaviour
{

    public GameObject Inventory;
    public InventoryItemData InventoryItemData;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            InventoryItemData.chargeJumpActive = 1;
            Destroy(gameObject);
        }
    }
}
