using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpawn : MonoBehaviour
{

    public GameObject myPrefab;
    public Camera myCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                Instantiate(myPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
