using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public Button djButton;
    public Button dashButton;
    public Button cjButton;
    public Button grapplerButton;
    public GameObject Player;
    public PlayerController PlayerController;
    public GameObject Grappler;
    public GrappleHook GrappleHook;

    // Start is called before the first frame update
    void Start()
    {
        djButton.gameObject.SetActive(false);
        dashButton.gameObject.SetActive(false);
        cjButton.gameObject.SetActive(false);
        grapplerButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleJumpActive == 1) {
            PlayerController.doubleJumpActive = true;
        }
        if (dashActive == 1) {
            PlayerController.dashActive = true;
        }
        if (chargeJumpActive == 1) {
            PlayerController.chargeJumpActive = true;
        }
        if (grapplerActive == 1) {
            PlayerController.grapplerActive = true;
            GrappleHook.grapplerEnabled = true;
        }
        if (doubleJumpActive == 1 || doubleJumpActive == 2) {
            djButton.gameObject.SetActive(true);
        }
        if (dashActive == 1 || dashActive == 2) {
            dashButton.gameObject.SetActive(true);
        }
        if (chargeJumpActive == 1 || chargeJumpActive == 2) {
            cjButton.gameObject.SetActive(true);
        }
        if (grapplerActive == 1 || grapplerActive == 2) {
            grapplerButton.gameObject.SetActive(true);
        }
    }
}
