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

    [SerializeField]
    KeyCode oppositeSpearKey;

    public InventoryItemData InventoryItemData;
    public PlayerController PlayerController;

    bool hasSpear = false;
    public bool spearEnabled;
    bool goUp = false;
    bool floating = true;
    bool spearFiring;
    bool spearJustEnd = false;
    float translated;
    float translatedDistance;



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





        if (spearEnabled)
        {
            if (spearJustEnd)
            {
                StartCoroutine(SpearCountdownRoutine());
                spearJustEnd = false;
            }
            if (Input.GetKey(spearKey) && !spearFiring)
            {
                Debug.Log("Spear Fired");
                spearFiring = true;
                transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.57f);
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                translated = 0;
            }

            else if (Input.GetKey(oppositeSpearKey) && !spearFiring)
            {
                Debug.Log("Spear Fired");
                spearFiring = true;
                transform.position = new Vector2(player.transform.position.x - 1.1f, player.transform.position.y + 0.57f);
                transform.eulerAngles = new Vector2(90, 0);
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                translated = 0;
            }


            if (spearFiring)
            {
                if (translated < 15)
                {
                    translated++;
                    translatedDistance += 0.07f;
                    transform.position = new Vector2(player.transform.position.x + 1.1f + translatedDistance, player.transform.position.y + 0.05f);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - 0.07f, player.transform.position.y + 0.05f);
                }
            }
        }
    }
    IEnumerator SpearCountdownRoutine() {
        gameObject.GetComponent<Renderer>().enabled = false;
        spearHead.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            translated = 0;
            translatedDistance = 0;
            spearFiring = false;
            if (!hasSpear) {
                hasSpear = true;
                InventoryItemData.spearActive = 1;
            }
            transform.position = new Vector2(0, -1000);
            gameObject.GetComponent<Renderer>().enabled = false;
            spearHead.GetComponent<Renderer>().enabled = false;
            transform.eulerAngles = new Vector2(0, 0);
            floating = false;
            spearJustEnd = true;
        }
    }
}
