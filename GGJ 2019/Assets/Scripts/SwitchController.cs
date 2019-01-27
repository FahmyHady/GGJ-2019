using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject effector;
    bool entered;
   
    // Update is called once per frame
    void Update()
    {
        if(entered&&Input.GetKeyDown(KeyCode.Z))
        {

            effector.SetActive(!effector.activeSelf);
        }
    }
    void OnDrawGizmos()
    {
        if(effector == null)
        {
            Debug.LogError("No target on "+gameObject.name);
        }
        Gizmos.color = Color.black / 2;
        Gizmos.DrawSphere(transform.position, GetComponent<CircleCollider2D>().radius);
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
