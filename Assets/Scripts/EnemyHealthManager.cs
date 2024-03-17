using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField]
    Image healthBar;

    [SerializeField]
    float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthAmount <= 0) {
            healthBar.Destroy();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(70);
        }
    }

    public void TakeDamage(float damage) {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }
}
