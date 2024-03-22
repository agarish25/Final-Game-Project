using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    public GameObject InventoryPanel;
    [SerializeField]
    KeyCode i; 
    bool pause = false;

    public PlayerHealthManager PlayerHealthManager;
    void Start() {
        InventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(i)) {
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
    }

    public void Continue() {
        InventoryPanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
        PlayerHealthManager.overallBar.SetActive(true);
    }
}
