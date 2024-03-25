using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HotbarSelector : MonoBehaviour
{
    [SerializeField]
    KeyCode a;
    [SerializeField]
    KeyCode b;
    [SerializeField]
    KeyCode c;
    [SerializeField]
    KeyCode d;

    int i = 0;

    // Update is called once per frame
    void Update()   
    {
        if (Input.GetKeyDown(a))
        {
            i = 0;
        }
        else if (Input.GetKeyDown(b))
        {
            i = 1;
        }
        else if (Input.GetKeyDown(c))
        {
            i = 2;
        }
        else if (Input.GetKeyDown(d))
        {
            i = 3;
        }
        transform.localPosition = new Vector2(-90 + 60 * i, -120);
    }
}
