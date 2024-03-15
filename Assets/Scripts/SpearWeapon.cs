    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject spearHead;

    [SerializeField]
    KeyCode spearKey;

    bool hasSpear = false;
    bool goUp = false;
    bool floating = true;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floating) {
            if (gameObject.transform.position.y >= -2.50) {
                goUp = false;
            }
            else if (gameObject.transform.position.y <= -3.0f) {
            goUp = true;
            }
            if (goUp) {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.015f);
            }
            else if (!goUp) {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.015f);
            }
        }
        
        



        if (hasSpear)
        {
            transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
            if (Input.GetKey(spearKey))
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
                StartCoroutine(SpearMovementCountdownRoutine());
                
                StartCoroutine(SpearCountdownRoutine());
                Debug.Log("Spear Weapon Initiated");

            }
        }
    }

    IEnumerator SpearCountdownRoutine() {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Renderer>().enabled = false;
        spearHead.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator SpearMovementCountdownRoutine() {
        yield return new WaitForSeconds(0.4f);
        transform.Translate(Vector2.right * Time.deltaTime * 30);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasSpear = true;
            transform.position = new Vector2(0, -1000);
            gameObject.GetComponent<Renderer>().enabled = false;
            spearHead.GetComponent<Renderer>().enabled = false;
            transform.eulerAngles = new Vector2(0, 0);
            floating = false;
        }
    }
}
