using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    public GameObject moveableObj;
    public GameObject end;
    public GameObject start;

    private bool isMoving = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //moveableObj.transform.parent = null;
            isMoving = true;
            //moveableObj.SetActive(false);
            
            Debug.Log("Player collision");
        }
    }

    private void Update()
    {

        float speed = 2f;
        if(isMoving)
        {
            moveableObj.transform.position = Vector3.MoveTowards(moveableObj.transform.
                position, end.transform.position, speed * Time.deltaTime); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveableObj.SetActive(true);

            Debug.Log("Player collision");
        }
    }
}
