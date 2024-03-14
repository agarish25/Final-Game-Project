using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemData : MonoBehaviour
{

    [SerializeField]
    public int doubleJumpActive;
    [SerializeField]
    public int dashActive;
    [SerializeField]
    public int chargeJumpActive;
    [SerializeField]
    public int grapplerActive;
    
    public GameObject Player;
    public PlayerController PlayerController;
    public GameObject Grappler;
    public GrappleHook GrappleHook;

    // Start is called before the first frame update
    void Start()
    {
        grapplerActive = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleJumpActive == 2) {
            PlayerController.doubleJumpActive = true;
        }
        if (dashActive == 2) {
            PlayerController.dashActive = true;
        }
        if (chargeJumpActive == 2) {
            PlayerController.chargeJumpActive = true;
        }
        if (grapplerActive == 2) {
            PlayerController.grapplerActive = true;
            GrappleHook.grapplerEnabled = true;
        }
    }
}
