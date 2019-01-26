using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject shadow;
    bool entered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(entered&&Input.GetKeyDown(KeyCode.Z))
        {
            ///////////////////////todo
            //Destroy(shadow);
            //Destroy(gameObject);
            //print(shadow.activeSelf);
            shadow.SetActive(!shadow.activeSelf);
        }
    }
    void OnDrawGizmos()
    {
        if(shadow==null)
        {
            Debug.LogError("No target on "+gameObject.name);
        }
        Gizmos.color = Color.black / 2;
        Gizmos.DrawSphere(transform.position, GetComponent<CircleCollider2D>().radius);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //print("ok");
        entered = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        entered = false;
    }
    /*void OnCollisionEnter2D(Collision2D col)
    {
        entered = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        entered = false;
    }*/
}
