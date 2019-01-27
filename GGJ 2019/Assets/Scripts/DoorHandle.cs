using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField]
    GameObject effector;
    bool entered;
    void Update()
    {/////////////////TODO
        if (entered && Input.GetKeyDown(KeyCode.Z))
        {
            effector.GetComponent<Animator>().Play("Opening");
            /*if (effector.transform.rotation.z < Quaternion.Euler(0, 0, 100).z)
            {
                Debug.Log(effector.transform.rotation.z +" "+ Quaternion.Euler(0, 0, 100).z);
                effector.transform.Rotate(0, 0, 1);
                effector.GetComponentInChildren<Collider2D>().isTrigger = true;
            }*/
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
