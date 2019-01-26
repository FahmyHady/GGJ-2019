using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMechanism : MonoBehaviour
{
    Vector3 mousePos;
    float m;
    float c;
    public float r;
    float i;
    float j;
    float k;
    Vector3 teleportPos;
    public GameObject shadow;
    public Material shadowMat;
    Vector3 heading;
    RaycastHit hit,obstacleCheck;
    Ray ray,ray2;
    float distance;
    bool blocked;
    
    Vector3 direction;
    void Start()
    {
        
    }
    void showTeleLoc()
    {
        shadow.gameObject.SetActive(true);
        shadow.transform.position = teleportPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out hit, 1000)  )
            {


                mousePos = hit.point;
                mousePos.z = transform.position.z;
                heading = mousePos - transform.position;
                distance = heading.magnitude;
                direction = heading / distance;
                if (!Physics.Raycast(transform.position, direction,r,9))
                {
                    
                  

                    if (distance < r)
                    {
                        blocked = false;
                        teleportPos = mousePos;

                    }
                    else
                    {
                    blocked = false;
                        teleportPos.x = transform.position.x + direction.x * r;
                        teleportPos.y = transform.position.y + direction.y * r;
                    }
                }
                else
                {
                    blocked = true;
                    teleportPos = mousePos;
                    StartCoroutine(changeColor());
                }
               
                showTeleLoc();
            }
        }
      
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (blocked == false)
            {
                

                transform.position = teleportPos;
            }
            shadow.gameObject.SetActive(false);
        }


    }
    public float SolveQuadratic(float a, float b, float c)

    {

        float sqrtpart = b * b - 4 * a * c;

        float x, x1, x2,y1,y2;

        if (sqrtpart > 0)

        {

            x1 = (-b + Mathf.Sqrt(sqrtpart)) / (2 * a);

            x2 = (-b - Mathf.Sqrt(sqrtpart)) / (2 * a);
            y1=m * x1 + c;
            y2 = m * x2 + c;
            Debug.Log("Two Real Solutions: " + x1 + ":::" + x2);
            if (Vector2.Distance(new Vector2(x1, y1), hit.point)< Vector2.Distance(new Vector2(x2, y2), hit.point))
            {
                return x1;
            }
            else
            {
                return x2;
            }
//             return Mathf.Min(Vector2.Distance(new Vector2(x1,y1),hit.point), Vector2.Distance(new Vector2(x2, y2), hit.point)); 

        }
     

        else

        {

            x = (-b + Mathf.Sqrt(sqrtpart)) / (2 * a);
            Debug.Log("One Real Solution: {0,8:f4}:::" + x);

            return x;

        }

    }
    IEnumerator changeColor()
    {
        shadowMat.color = Color.red;
        yield return new WaitUntil(()=> blocked==false );
        shadowMat.color = Color.black;

    }
}
