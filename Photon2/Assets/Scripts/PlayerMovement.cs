using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public float Speed;
    private Camera playerCam;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
        if (PV.IsMine)
        {
            playerCam = FindObjectOfType<Camera>();
            playerCam.transform.SetParent(this.transform);
            playerCam.transform.localPosition = new Vector3(0, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            //playerCam = Camera.main;
            basicMovement();
            basicRot();
        }
    }
     void basicMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * Speed);
        }
    }
     void basicRot()
    {
        float xMouse = Input.GetAxis("Mouse X") *Time.deltaTime *rotSpeed;
        transform.Rotate(new Vector3(0, xMouse, 0));
    }
}
