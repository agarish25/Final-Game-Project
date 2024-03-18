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
        if (Input.GetKeyDown(KeyCode.H)) {
            TakeDamage(25);
        }
    }

    public void TakeDamage(float damage) {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }
}
