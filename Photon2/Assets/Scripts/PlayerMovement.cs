using System.Collections;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public bool canAtt;
    public float Speed;
    public Material newmat;
    private Camera playerCam;
    private Vector3 playerForward;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        newmat = this.GetComponentInChildren<MeshRenderer>().material;
        Debug.Log(newmat);
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
        //this.PV.RPC("displayCol", RpcTarget.AllBuffered);
        if (PV.IsMine)
        {
            canAtt = true;
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
            playerForward = this.transform.forward;
            //playerCam = Camera.main;
            basicMovement();
            basicRot();
            basicAtt();
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

    void basicAtt()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAtt)
        {
            GameObject proj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet"), (transform.position + playerForward * 2f), Quaternion.identity);
            proj.GetComponent<MeshRenderer>().material = newmat;
            Debug.Log(proj.GetComponent<MeshRenderer>().material);
            proj.GetComponent<Rigidbody>().AddForce(transform.position + playerForward* 500);
            PV.RPC("displayCol", RpcTarget.All);
            //proj.GetPhotonView().RPC("displayCol", RpcTarget.AllBuffered);
            canAtt = false;
            StartCoroutine(attackDelay());
        }
    }
    IEnumerator attackDelay()
    {
        yield return new WaitForSeconds(1);
        canAtt = true;
        //yield break;

    }
    [PunRPC]
    void displayCol()
    {
        this.GetComponentInChildren<MeshRenderer>().material = newmat;
        Debug.Log(this.gameObject.GetComponentInChildren<MeshRenderer>().material);
    }
}
