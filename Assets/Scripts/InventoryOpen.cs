using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpen : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject MapPanel;
    [SerializeField]
    KeyCode i;
    [SerializeField]
    Canvas canvas1;
    public bool pause = false;
    [SerializeField]
    InventoryItemData InventoryItemData;
    [SerializeField]
    Button d;
    [SerializeField]
    Button g;
    [SerializeField]
    Button s;


    public PlayerHealthManager PlayerHealthManager;
    void Start() {
        d.gameObject.SetActive(false);
        g.gameObject.SetActive(false);
        s.gameObject.SetActive(false);
        InventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(i) && !MapPanel.activeInHierarchy) {
            if (pause) {
                this.Continue();
            }
            else {
                this.Pause();
            }
        }

    }

    public void Pause() {
        InventoryPanel.SetActive(true);
        Time.timeScale = 0;
        pause = true;
        PlayerHealthManager.overallBar.SetActive(false);
        canvas1.gameObject.SetActive(false);
        d.gameObject.SetActive(false);
        g.gameObject.SetActive(false);
        s.gameObject.SetActive(false);
    }

    public void Continue() {
        InventoryPanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
        PlayerHealthManager.overallBar.SetActive(true);
        canvas1.gameObject.SetActive(true);
        if (InventoryItemData.dashActive == 2 || InventoryItemData.dashActive == 3)
        {
            d.gameObject.SetActive(true);
            int i = 0;
            for (int a = 0; a < 4; a++)
            {
                if (InventoryItemData.equippedData[a] == 2)
                {
                    i = a;
                }
            }
            d.transform.localPosition = new Vector2(-90 + 60 * i, -120);
        }
        else
        {
            d.gameObject.SetActive(false);
        }
        if (InventoryItemData.spearActive == 2 || InventoryItemData.spearActive == 3)
        {
            s.gameObject.SetActive(true);
            int i = 0;
            for (int a = 0; a < 4; a++)
            {
                if (InventoryItemData.equippedData[a] == 5)
                {
                    i = a;
                }
            }
            s.transform.localPosition = new Vector2(-90 + 60 * i, -120);
        }
        else
        {
            s.gameObject.SetActive(false);
        }
        if (InventoryItemData.grapplerActive == 2 || InventoryItemData.grapplerActive == 3)
        {
            g.gameObject.SetActive(true);
            int i = 0;
            for (int a = 0; a < 4; a++)
            {
                if (InventoryItemData.equippedData[a] == 4)
                {
                    i = a;
                }
            }
            g.transform.localPosition = new Vector2(-90 + 60 * i, -120);
        }
        else
        {
            g.gameObject.SetActive(false);
        }
    }
}
