using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    bool goUp = false;
    bool floating = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (floating)
        {
            if (gameObject.transform.position.y >= -2.75)
            {
                goUp = false;
            }
            else if (gameObject.transform.position.y <= -3.0f)
            {
                goUp = true;
            }
            if (goUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.015f);
            }
            else if (!goUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.015f);
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(0, 1000);
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
