using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController.isOnGround = false;
    }

    private void Update()
    {
        //Debug.Log(playerController.isOnGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("left");
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.isOnGround = false;
            if (playerController.doubleJumpActive)
            {
                playerController.doubleJump = true;
            }
        }
    }
}
