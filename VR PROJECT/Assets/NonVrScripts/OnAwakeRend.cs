using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeRend : MonoBehaviour
{
    bool checkForPlayer = false;
    private void Update()
    {
        
        if (checkForPlayer != true)
        {
            checkForPlayer = true;
            StartCoroutine(disableRender());

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.transform.tag);
    //    if (collision != null)
    //    {
    //        Debug.Log(collision.transform.tag);
    //        return;
    //    }
    //    else
    //    {
    //        StartCoroutine(disableRender());
    //    }
        
    //}
    IEnumerator disableRender()
    {
        yield return new WaitForSeconds(1);
        ParticleSystem ps = this.GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.enabled = false;
        checkForPlayer = false;
        Debug.Log("disabled");
    }
}
