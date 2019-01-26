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
    RaycastHit hit;
    Ray ray;
    float distance;
    bool blocked;
    [SerializeField]
    GameObject teloportEffect;
    Vector3 direction;
    float zPos;
    [SerializeField]
    AudioClip teleportationAudio;
    void Start()
    {
        zPos = transform.position.z;
        shadowMat.color = Color.black;
    }
    void showTeleLoc()
    {
        shadow.gameObject.SetActive(true);
        shadow.transform.position = teleportPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&&PlayerControl.Grounded==true)
        {
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
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartCoroutine(TeleportAnimation());
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
        PlayerControl.animator.Play("teleport");
        yield return new WaitForSeconds(PlayerControl.animator.GetCurrentAnimatorClipInfo(0).Length);

        if (blocked == false)
        {

            ///////
            AudioSource.PlayClipAtPoint(teleportationAudio, GameManager.instance.mainCamera.transform.position);
            Destroy(Instantiate(teloportEffect, transform.position, Quaternion.identity), 2);
            teleportPos.z = zPos;
            transform.position = teleportPos;
            Destroy(Instantiate(teloportEffect, transform.position, Quaternion.identity), 2);



        }
        shadow.gameObject.SetActive(false);
    }
}
