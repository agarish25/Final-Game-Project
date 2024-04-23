using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("collided");
            playerController.isOnGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn"))
        {
            playerController.isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("left");
            playerController.isOnGround = false;
            if (playerController.doubleJumpActive)
            {
                playerController.doubleJump = true;
            }
        }
    }
}
