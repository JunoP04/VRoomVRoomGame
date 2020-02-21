using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCol : MonoBehaviour
{
    public Material newMat;
    
    private void OnCollisionEnter(Collision collision)
    {
        newMat = this.gameObject.GetComponent<MeshRenderer>().material;
        Debug.Log(collision.transform.tag);
        collision.gameObject.GetComponent<MeshRenderer>().material = newMat;
        Destroy(this.gameObject);
    }
}
