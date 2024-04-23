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
    [SerializeField]
    public int healthGemActive;
    [SerializeField]
    InventoryOpen InventoryOpen;

    public int djChange = 0;
    public int dChange = 0;
    public int cjChange = 0;
    public int gChange = 0;
    public int sChange = 0;
    public int hgChange = 0;

    public Button djButton;
    public Button dashButton;
    public Button cjButton;
    public Button grapplerButton;
    public Button spearButton;
    public Button hgButton;
    public GameObject Player;
    public PlayerController PlayerController;
    public GameObject Grappler;
    public GrappleHook GrappleHook;
    public SpearWeapon SpearWeapon;

    public int[] inventoryData = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public int[] equippedData = {0, 0, 0, 0};
    public int[] passiveData = { 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        djButton.gameObject.SetActive(false);
        dashButton.gameObject.SetActive(false);
        cjButton.gameObject.SetActive(false);
        grapplerButton.gameObject.SetActive(false);
        spearButton.gameObject.SetActive(false);
        hgButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((doubleJumpActive == 2 || doubleJumpActive == 3) && (djChange == 2 || djChange == 3))
        {
         
        }
        else if (djChange != doubleJumpActive) {
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
            else if (doubleJumpActive == 2 || doubleJumpActive == 3) {
                for (int j = 0; j < 2; j++) {
                    if (passiveData[j] == 0) {
                        equippedData[j] = 1;
                        djButton.gameObject.transform.localPosition = new Vector2(300 * -(((j + 1) % 2) * 2 - 1), -80);
                        j = 2;
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
                for (int i = 0; i < 2; i++) {
                    if (passiveData[i] == 1) {
                        passiveData[i] = 0;
                    }
                }
            }
            djChange = doubleJumpActive;
        }
        if ((dashActive == 2 || dashActive == 3) && (dChange == 2 || dChange == 3))
        {

        }
        else if (dChange != dashActive) {
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
            else if (dashActive == 2 || dashActive == 3) {
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
        if ((chargeJumpActive == 2 || chargeJumpActive == 3) && (cjChange == 2 || cjChange == 3))
        {

        }
        else if (cjChange != chargeJumpActive) {
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
            else if (chargeJumpActive == 2 || chargeJumpActive == 3) {
                for (int j = 0; j < 2; j++) {
                    if (passiveData[j] == 0) {
                        passiveData[j] = 3;
                        cjButton.gameObject.transform.localPosition = new Vector2(300 * -(((j + 1) % 2) * 2 - 1), -80);
                        j = 2;
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
                for (int i = 0; i < 2; i++) {
                    if (passiveData[i] == 3) {
                        passiveData[i] = 0;
                    }
                }
            }
            cjChange = chargeJumpActive;
        }
        if ((grapplerActive == 2 || grapplerActive == 3) && (gChange == 2 || gChange == 3))
        {

        }
        else if (gChange != grapplerActive) {
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
            else if (grapplerActive == 2 || grapplerActive == 3) {
                for (int j = 0; j < 4; j++) {
                    if (equippedData[j] == 0) {
                        equippedData[j] = 4;
                        grapplerButton.gameObject.transform.localPosition = new Vector2(-180 + 120 * j, -80);
                        j = 4;
                    }
                }
            }
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
        if (hgChange != healthGemActive)
        {
            hgButton.gameObject.SetActive(true);
            if (healthGemActive == 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (inventoryData[i] == 0)
                    {
                        inventoryData[i] = 6;
                        hgButton.gameObject.transform.localPosition = new Vector2(-300 + 120 * i, 80);
                        i = 12;
                    }
                }
            }
            else if (healthGemActive == 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (passiveData[j] == 0)
                    {
                        passiveData[j] = 6;
                        hgButton.gameObject.transform.localPosition = new Vector2(300 * -(((j + 1) % 2) * 2 - 1), -80);
                        j = 2;
                    }
                }
            }
            if (hgChange == 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (inventoryData[i] == 6)
                    {
                        inventoryData[i] = 0;
                    }
                }
            }
            else if (hgChange == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (passiveData[i] == 6)
                    {
                        passiveData[i] = 0;
                    }
                }
            }
            hgChange = healthGemActive;
        }
        if (doubleJumpActive == 2) {
            PlayerController.doubleJumpActive = true;
        }
        else {
            PlayerController.doubleJumpActive = false;
        }
        if (dashActive == 3) {
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
        if (grapplerActive == 3) {
            PlayerController.grapplerActive = true;
            GrappleHook.grapplerEnabled = true;
        }
        else {
            PlayerController.grapplerActive = false;
            GrappleHook.grapplerEnabled = false;
        }
        if (spearActive == 3) {
            SpearWeapon.spearEnabled = true;
        }
        else {
            SpearWeapon.spearEnabled = false;
        }
        if (healthGemActive == 2)
        {
            PlayerController.healthGemActive = true;
        }
        else
        {
            PlayerController.healthGemActive = false;
        }
    }

    public void djClicked() {
        if (InventoryOpen.pause)
        {
            if (doubleJumpActive == 1)
            {
                doubleJumpActive = 2;
            }
            else
            {
                doubleJumpActive = 1;
            }
        }
    }

    public void cjClicked() {
        if (InventoryOpen.pause)
        {
            if (chargeJumpActive == 1)
            {
                chargeJumpActive = 2;
            }
            else
            {
                chargeJumpActive = 1;
            }
        }
    }

    public void dClicked() {
        if (InventoryOpen.pause)
        {
            if (dashActive == 1)
            {
                dashActive = 2;
            }
            else
            {
                dashActive = 1;
            }
        }
    }

    public void gClicked() {
        if (InventoryOpen.pause)
        {
            if (grapplerActive == 1)
            {
                grapplerActive = 2;
            }
            else
            {
                grapplerActive = 1;
            }
        }
    }
    
    public void sClicked() {
        if (InventoryOpen.pause)
        {
            if (spearActive == 1)
            {
                spearActive = 2;
            }
            else
            {
                spearActive = 1;
            }
        }
    }
    public void hgClicked()
    {
        if (InventoryOpen.pause)
        {
            if (healthGemActive == 1)
            {
                healthGemActive = 2;
            }
            else
            {
                healthGemActive = 1;
            }
        }
    }
}
