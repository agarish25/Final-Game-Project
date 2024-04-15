using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public GameObject MapPanel;
    public GameObject InventoryPanel;
    public GameObject healthPanel;
    public GameObject hotbar;
    [SerializeField]
    KeyCode m;
    public bool pause = false;

    private void Start()
    {
        MapPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(m) && !InventoryPanel.activeInHierarchy)
        {
            if (pause)
            {
                this.Continue();
            }
            else
            {
                this.Pause();
            }
        }
    }

    public void Pause()
    {
        MapPanel.SetActive(true);
        Time.timeScale = 0;
        pause = true;
        healthPanel.SetActive(false);
        hotbar.SetActive(false);
    }

    public void Continue()
    {
        MapPanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
        healthPanel.SetActive(true);
        hotbar.SetActive(true);
    }
}
