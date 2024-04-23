using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutScript : MonoBehaviour
{
    public GameObject floors;

    private void Start()
    {
        floors.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("exited");
            floors.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("entered");
            floors.SetActive(false);
        }
    }
}
