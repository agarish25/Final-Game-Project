using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //isOnGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //playerisOnGround = false;
        }
    }
}
