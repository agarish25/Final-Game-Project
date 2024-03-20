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
    [SerializeField]
    public int spearActive;

    int djChange = 0;
    int dChange = 0;
    int cjChange = 0;
    int gChange = 0;
    int sChange = 0;

    public Button djButton;
    public Button dashButton;
    public Button cjButton;
    public Button grapplerButton;
    public Button spearButton;
    public GameObject Player;
    public PlayerController PlayerController;
    public GameObject Grappler;
    public GrappleHook GrappleHook;
    public SpearWeapon SpearWeapon;

    public int[] inventoryData = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public int[] equippedData = {0, 0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        djButton.gameObject.SetActive(false);
        dashButton.gameObject.SetActive(false);
        cjButton.gameObject.SetActive(false);
        grapplerButton.gameObject.SetActive(false);
        spearButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (djChange != doubleJumpActive) {
            djButton.gameObject.SetActive(true);
            if (doubleJumpActive == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 0) {
                        inventoryData[i] = 1;
                        djButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        i = 12;
                    }
                }
            }
            else if (doubleJumpActive == 2) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 1;
                        djButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                }
            }
            if (djChange == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 1) {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (djChange == 2) {
                for (int i = 0; i < 4; i++) {
                    if (equippedData[i] == 1) {
                        equippedData[i] = 0;
                    }
                }
            }
            djChange = doubleJumpActive;
        }
        if (dChange != dashActive) {
            dashButton.gameObject.SetActive(true);
            if (dashActive == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 0) {
                        inventoryData[i] = 2;
                        dashButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        i = 12;
                    }
                }
            }
            else if (dashActive == 2) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 2;
                        dashButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                }
            }
            if (dChange == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 2) {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (dChange == 2) {
                for (int i = 0; i < 4; i++) {
                    if (equippedData[i] == 2) {
                        equippedData[i] = 0;
                    }
                }
            }
            dChange = dashActive;
        }
        if (cjChange != chargeJumpActive) {
            cjButton.gameObject.SetActive(true);
            if (chargeJumpActive == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 0) {
                        inventoryData[i] = 3;
                        cjButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        i = 12;
                    }
                }
            }
            else if (chargeJumpActive == 2) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 3;
                        cjButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                }
            }
            if (cjChange == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 3) {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (cjChange == 2) {
                for (int i = 0; i < 4; i++) {
                    if (equippedData[i] == 3) {
                        equippedData[i] = 0;
                    }
                }
            }
            cjChange = chargeJumpActive;
        }
        if (gChange != grapplerActive) {
            grapplerButton.gameObject.SetActive(true);
            if (grapplerActive == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 0) {
                        grapplerButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        inventoryData[i] = 4;
                        i = 12;
                    }
                }
            }
            else if (grapplerActive == 2) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 4;
                        grapplerButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                }
            }
            Debug.Log(inventoryData);
            if (gChange == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 4) {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (gChange == 2) {
                for (int i = 0; i < 4; i++) {
                    if (equippedData[i] == 4) {
                        equippedData[i] = 0;
                    }
                }
            }
            gChange = grapplerActive;
        }
        if (sChange != spearActive) {
            spearButton.gameObject.SetActive(true);
            if (spearActive == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 0) {
                        spearButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        inventoryData[i] = 5;
                        i = 12;
                    }
                }
            }
            else if (spearActive == 2) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 5;
                        spearButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                    else if (j == 3) {
                         sChange = 0;
                    }
                }
            }
            if (sChange == 1) {
                for (int i = 0; i < 12; i++) {
                    if (inventoryData[i] == 5) {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (sChange == 2) {
                for (int i = 0; i < 4; i++) {
                    if (equippedData[i] == 5) {
                        equippedData[i] = 0;
                    }
                }
            }
            sChange = spearActive;
        }
        if (doubleJumpActive == 2) {
            PlayerController.doubleJumpActive = true;
        }
        else {
            PlayerController.doubleJumpActive = false;
        }
        if (dashActive == 2) {
            PlayerController.dashActive = true;
        }
        else {
            PlayerController.dashActive = false;
        }
        if (chargeJumpActive == 2) {
            PlayerController.chargeJumpActive = true;
        }
        else {
            PlayerController.chargeJumpActive = false;
        }
        if (grapplerActive == 2) {
            PlayerController.grapplerActive = true;
            GrappleHook.grapplerEnabled = true;
        }
        else {
            PlayerController.grapplerActive = false;
            GrappleHook.grapplerEnabled = false;
        }
        if (spearActive == 2) {
            SpearWeapon.spearEnabled = true;
        }
        else {
            SpearWeapon.spearEnabled = false;
        }
    }

    public void djClicked() {
        if (doubleJumpActive == 1) {
            doubleJumpActive = 2;
        }
        else {
            doubleJumpActive = 1;
        }
    }

    public void cjClicked() {
        if (chargeJumpActive == 1) {
            chargeJumpActive = 2;
        }
        else {
            chargeJumpActive = 1;
        }
    }

    public void dClicked() {
        if (dashActive == 1) {
            dashActive = 2;
        }
        else {
            dashActive = 1;
        }
    }

    public void gClicked() {
        if (grapplerActive == 1) {
            grapplerActive = 2;
        }
        else {
            grapplerActive = 1;
        }
    }
    
    public void sClicked() {
        if (spearActive == 1) {
            spearActive = 2;
        }
        else {
            spearActive = 1;
        }
    }
}
