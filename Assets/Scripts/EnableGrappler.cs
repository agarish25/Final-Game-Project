using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGrappler : MonoBehaviour
{

    public GameObject Grappler;
    public GrappleHook GrappleHook;
    public GameObject Inventory;
    public InventoryItemData InventoryItemData;

    // Start is called before the first frame update
    void Start()
    {
        GrappleHook = Grappler.GetComponent<GrappleHook>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryItemData.grapplerActive = 1;
            Destroy(gameObject);
        }
    }
}
