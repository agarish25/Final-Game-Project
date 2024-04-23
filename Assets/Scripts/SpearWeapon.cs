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
    public bool spearForward = true;

    bool hasSpear = false;
    public bool spearEnabled;
    bool spearFiring;
    bool spearJustEnd = false;
    float translated;
    float translatedDistanceForward;
    float translatedDistanceBackward;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        spearEnabled = true;
        if (spearEnabled)
        {
            Debug.Log("Enabled");
            if (spearJustEnd)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                spearHead.GetComponent<Renderer>().enabled = false;
                spearJustEnd = false;
            }
            if (Input.GetKeyDown(spearKey))
            {
                Debug.Log("Spear Fired");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                spearForward = true;
                spearFiring = true;
                transform.position = new Vector2(player.transform.position.x + 1.1f, player.transform.position.y + 0.57f);
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                translated = 0;
            }

            if (Input.GetKeyDown(oppositeSpearKey) && !spearFiring)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                spearForward = false;
                Debug.Log("Opposite Spear Fired");
                spearFiring = true;
                transform.position = new Vector2(player.transform.position.x - 10.1f, player.transform.position.y + 0.57f);
                transform.eulerAngles = new Vector2(90, 0);
                gameObject.GetComponent<Renderer>().enabled = true;
                spearHead.GetComponent<Renderer>().enabled = true;
                translated = 0;
            }


            if (spearFiring && spearForward)
            {
                if (translated < 15)
                {
                    translated++;
                    translatedDistanceForward += 0.07f;
                    transform.position = new Vector2(player.transform.position.x + 1.1f + translatedDistanceForward, player.transform.position.y + 0.05f);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - 0.07f, player.transform.position.y + 0.05f);
                }
            }

            if (spearFiring && !spearForward)
            {
                if (translated < 15)
                {
                    translated++;
                    translatedDistanceBackward -= 0.07f;
                    transform.position = new Vector2(player.transform.position.x - 1.1f + translatedDistanceBackward, player.transform.position.y + 0.05f);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x + 0.07f, player.transform.position.y + 0.05f);
                }
            }
        }
    }

    IEnumerator SpearCountdownRoutine()
    {
        
        yield return new WaitForSeconds(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            translated = 0;
            translatedDistanceForward = 0;
            translatedDistanceBackward = 0;
            spearFiring = false;
            if (!hasSpear) {
                hasSpear = true;
                InventoryItemData.spearActive = 1;
            }
            transform.position = new Vector2(0, -1000);
            gameObject.GetComponent<Renderer>().enabled = false;
            spearHead.GetComponent<Renderer>().enabled = false;
            transform.eulerAngles = new Vector2(0, 0);
            spearJustEnd = true;
            spearEnabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            translated = 15;
        }
    }
}
