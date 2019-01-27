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
    Rigidbody2D playerBody;
    Vector3 teleportPos;
    public GameObject shadow;
    public Material shadowMat;
    Vector3 heading;
    RaycastHit hit;
    Ray ray;
    float distance;
    bool blocked;
    [SerializeField]
    GameObject teloportEffect1, teloportEffect2;
    Vector3 direction;
    float zPos;
    [SerializeField]
    AudioClip teleportationAudio;
    bool isTeleporting;
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        zPos = transform.position.z;
        shadowMat.color = Color.white;
    }
    void showTeleLoc()
    {
        shadow.gameObject.SetActive(true);
        shadow.transform.position = teleportPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&&PlayerControl.Grounded==true&&!isTeleporting)
        {
            playerBody.velocity = new Vector2(0, playerBody.velocity.y);
            PlayerControl.canMove = false;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            PlayerControl.animator.Play("teleport2");

            if (Physics.Raycast(ray, out hit, 1000))
            {


                mousePos = hit.point;
                mousePos.z = transform.position.z;
                heading = mousePos - transform.position;
                distance = heading.magnitude;
                direction = heading / distance;
                if (!Physics2D.Raycast(transform.position, direction, distance, 9))
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
            if(transform.position.x>hit.point.x)
            {
                PlayerControl.instance.mybody.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else
            {
                PlayerControl.instance.mybody.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)&&!isTeleporting)
        {
            if (blocked ==false)
            {
                PlayerControl.canMove = false;
                StartCoroutine(TeleportAnimation());
            }
            else
            {
                PlayerControl.canMove = true;
                PlayerControl.animator.Play("Idle");

            }
            shadow.gameObject.SetActive(false);

        }


    }
    public float SolveQuadratic(float a, float b, float c)

    {

        float sqrtpart = b * b - 4 * a * c;

        float x, x1, x2, y1, y2;

        if (sqrtpart > 0)

        {

            x1 = (-b + Mathf.Sqrt(sqrtpart)) / (2 * a);

            x2 = (-b - Mathf.Sqrt(sqrtpart)) / (2 * a);
            y1 = m * x1 + c;
            y2 = m * x2 + c;
            Debug.Log("Two Real Solutions: " + x1 + ":::" + x2);
            if (Vector2.Distance(new Vector2(x1, y1), hit.point) < Vector2.Distance(new Vector2(x2, y2), hit.point))
            {
                return x1;
            }
            else
            {
                return x2;
            }

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
        yield return new WaitUntil(() => blocked == false);
        shadowMat.color = Color.black;

    }
    IEnumerator TeleportAnimation()
    {
        isTeleporting = true;
        PlayerControl.animator.Play("teleport");
        Destroy(Instantiate(teloportEffect1, transform.position, Quaternion.identity), 8);

        yield return new WaitForSeconds(2);
        
        

            ///////
           AudioSource.PlayClipAtPoint(teleportationAudio, GameManager.instance.mainCamera.transform.position);
            teleportPos.z = zPos;
            transform.position = teleportPos;
            Destroy(Instantiate(teloportEffect2, transform.position, Quaternion.identity), 2);



        
        yield return new WaitForSeconds(2);
        PlayerControl.canMove = true;
        isTeleporting = false;


    }
}
