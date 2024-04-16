using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject anchor1;
    public GameObject anchor2;
    public float speed;

    public bool toA1;

    private void Start()
    {
        toA1 = false;
    }

    private void FixedUpdate()
    {
        var heading = gameObject.transform.position;
        if (toA1)
        {
            heading = anchor1.transform.position - gameObject.transform.position;
        }
        else
        {
            heading = anchor2.transform.position - gameObject.transform.position;
        }
        var distance = heading.magnitude;
        var direction = heading / distance;
        if (distance < 0.02f)
        {
            toA1 = !toA1;
        }
        else
        {
            gameObject.transform.position = new Vector2(transform.position.x + direction.x * speed, transform.position.y + direction.y * speed);
        }
        Debug.Log(toA1 + " " + distance);
    }
}
