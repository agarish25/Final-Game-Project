using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public GameObject MapPanel;
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
        if (Input.GetKeyDown(m))
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
    }

    public void Continue()
    {
        MapPanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
}
