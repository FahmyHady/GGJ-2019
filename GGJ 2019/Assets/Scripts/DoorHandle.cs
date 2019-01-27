using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField]
    GameObject effector;
    bool entered;

    void Update()
    {
        if (entered && Input.GetKey(KeyCode.Z))
        {
            if (effector.transform.eulerAngles.z < 100)
            {
                effector.transform.Rotate(0, 0, 1);
                effector.GetComponentInChildren<Collider2D>().isTrigger = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        entered = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        entered = false;
    }
}
