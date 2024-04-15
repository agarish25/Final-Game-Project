using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public Button startGameButton;
    public RectTransform blankPanel;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            Time.timeScale = 1;
        }
        else if (!isGameActive)
        {
            Time.timeScale = 0;
        }
    }

    public void StartGame() {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);
        blankPanel.gameObject.SetActive(false);
    }
}
