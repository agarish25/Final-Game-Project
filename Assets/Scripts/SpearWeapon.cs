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
    bool spearFiring;
    float translated;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floating)
        {
            if (gameObject.transform.position.y >= -2.50)
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





        if (hasSpear)
        {
            if (Input.GetKey(spearKey))
            {
                Debug.Log("Spear Fired");
                spearFiring = true;
                transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.05f);
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                translated = 0;
            }
            if (spearFiring)
            {
                if (translated < 10000)
                {
                    Debug.Log(transform.position);
                    translated++;
                    transform.position = new Vector2(transform.position.x + 0.001f, transform.position.y);
                }
                else
                {
                    spearFiring = false;
                    transform.position = new Vector2(0, -1000);
                    StartCoroutine(SpearCountdownRoutine());
                    Debug.Log("Spear Weapon Initiated");
                }
            }
        }
    }
    IEnumerator SpearCountdownRoutine() {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Renderer>().enabled = false;
        spearHead.GetComponent<Renderer>().enabled = false;
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
