using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public bool damageTaken;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damageTaken = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((collision.gameObject.CompareTag("Spear")) || (collision.gameObject.CompareTag("Player"))) && (collision.gameObject.GetComponent<Renderer>().enabled == true))
        {
            health -= 25;
            damageTaken = true;
        }
        damageTaken = false;
    }
}
