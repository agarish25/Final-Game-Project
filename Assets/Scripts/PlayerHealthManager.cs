using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    Image healthBar;

    [SerializeField]
    GameObject overallBar;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    PlayerController PlayerController;

    [SerializeField]
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Player.transform.position = new Vector2(PlayerController.xSpawn, PlayerController.ySpawn);
            PlayerController.deaths++;
            healthAmount = 100;
        }
        healthBar.fillAmount = healthAmount / 100.0f; 
    }
}
