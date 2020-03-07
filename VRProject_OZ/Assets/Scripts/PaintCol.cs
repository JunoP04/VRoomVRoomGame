using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCol : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.tag = "AllyZombie";
            collision.gameObject.GetComponent<Pathing>().enemyType  = "Zombie";
        }
        Destroy(this.gameObject);
    }
}
