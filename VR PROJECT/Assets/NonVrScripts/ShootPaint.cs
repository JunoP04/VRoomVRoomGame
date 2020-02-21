using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaint : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject mainCam;
    public GameObject playerCharacter;
    public GameObject paintBall;
    public Vector3 aimPoint;
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
        //    aimPoint = hit.point;
        //}


        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            GameObject ballInstance = Instantiate(paintBall, spawnPoint.transform.position, Quaternion.identity);
            ballInstance.GetComponent<MeshRenderer>().material = playerCharacter.GetComponent<MeshRenderer>().material;
            Rigidbody ballRB = ballInstance.GetComponent<Rigidbody>();
            //ballInstance.transform.SetParent(spawnPoint.transform);
            ballRB.AddForce(transform.forward * 1000);
            canShoot = false;
            StartCoroutine(shootDelay());
            //ballInstance.transform.parent = null;
        }
        
    }
    public IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
