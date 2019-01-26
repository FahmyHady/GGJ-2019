using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  public  Transform player;
    Vector3 offset;
    private void Start()
    {
        offset = new Vector3(-5, 0, 10);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position= player.position + offset;
    }
}
