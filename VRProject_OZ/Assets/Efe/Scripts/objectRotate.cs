using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRotate : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 2f * Time.deltaTime, 0);
    }
}
