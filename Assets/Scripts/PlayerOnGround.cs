using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    public float platformGap;
    // Start is called before the first frame update
    void Start()
    {
        playerController.isOnGround = false;
    }

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn") || collision.gameObject.CompareTag("Moving Platform"))
        {
            playerController.isOnGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn") || collision.gameObject.CompareTag("Moving Platform"))
        {
            playerController.isOnGround = true;
            if (collision.gameObject.CompareTag("Moving Platform"))
            {
               // transform.position = new Vector2(transform.position.x + )
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn") || collision.gameObject.CompareTag("Moving Platform"))
        {
            playerController.isOnGround = false;
            if (playerController.doubleJumpActive)
            {
                playerController.doubleJump = true;
            }
        }
    }
}
