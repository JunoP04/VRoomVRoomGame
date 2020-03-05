using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatter : MonoBehaviour
{

    public GameObject player;
    public Rigidbody[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance < 10f)
        {
            Debug.Log("distance check");
            Rigidbody thisRB = this.GetComponent<Rigidbody>();
            thisRB.AddExplosionForce(100f, this.transform.position, 5f, 3);
             foreach(Rigidbody piece in pieces)
            {
                piece.AddExplosionForce(100f, piece.transform.position, 25f, 3f);
            }
        }
    }
}
