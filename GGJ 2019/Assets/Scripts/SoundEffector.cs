using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip [] myEffects;
    //AudioSource.PlayClipAtPoint(miaw1, new Vector2(0, 0));
    void Start()
    {
        StartCoroutine(StartEffect());
    }
    IEnumerator StartEffect()
    {
        yield return new WaitForSeconds(2);
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(4,8.0f));
            AudioSource.PlayClipAtPoint(myEffects[Random.Range(0, myEffects.Length)], GameManager.instance.mainCamera.transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
