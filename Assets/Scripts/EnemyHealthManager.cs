using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField]
    Image healthBar;

    [SerializeField]
    GameObject overallBar;

    public EnemyController EnemyController;

    [SerializeField]
    float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(overallBar);
        }
        healthBar.fillAmount = EnemyController.health / 100.0f; 
    }
}
