using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorHandle : MonoBehaviour
{
    [SerializeField]
    GameObject effector;
    bool entered;

    void Update()
    {
        if (entered )
        {
                effector.transform.Rotate(0, 0, 1);

            if (effector.transform.eulerAngles.z < 100)
            {
                effector.gameObject.transform.rotation = new Quaternion(0, 0, 100, effector.transform.rotation.w);
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
