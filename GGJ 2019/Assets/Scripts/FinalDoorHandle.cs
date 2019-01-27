using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorHandle : MonoBehaviour
{
    [SerializeField]
    GameObject effector;
    public GameObject finalspot;
    bool entered;
    void Update()
    {/////////////////TODO
        if (entered && Input.GetKeyDown(KeyCode.Z))
        {
            effector.GetComponent<Animator>().Play("Opening");
            StartCoroutine(end());
        }
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(1.5f);
        finalspot.SetActive(true);
        
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
