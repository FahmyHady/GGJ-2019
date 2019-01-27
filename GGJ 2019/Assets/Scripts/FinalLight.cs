using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLight : MonoBehaviour
{
    Light mylight;
    void Start()
    {
        mylight = GetComponent<Light>();
        mylight.intensity = 0;

    }
    
    // Update is called once per frame
    void Update()
    {
        mylight.intensity += 0.2f;
    }
}
