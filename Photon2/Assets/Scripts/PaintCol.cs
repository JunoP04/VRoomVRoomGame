using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PaintCol : MonoBehaviourPunCallbacks
{
    public Material newMat;
    public PhotonView PV;
    public GameObject self;

    private void Start()
    {
        self = this.gameObject;
        PV = GetComponent<PhotonView>();
        newMat = this.gameObject.GetComponent<MeshRenderer>().material;
        if (PV.IsMine)
        {
            PV.RPC("changeCol", RpcTarget.AllBuffered);
        }
        Debug.Log(newMat);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log(collision.gameObject);
        collision.gameObject.GetComponent<MeshRenderer>().material = newMat;
        PhotonNetwork.Destroy(this.gameObject);

    }
    [PunRPC]
    void changeCol()
    {
        gameObject.GetComponent<MeshRenderer>().material = newMat;
        //ob.GetComponent<MeshRenderer>().material = newMat;
        //PhotonNetwork.Destroy(this.gameObject);
    }
    //[PunRPC]
    //void displayCol()
    //{
    //    gameObject.GetComponent<MeshRenderer>().material = newMat;
    //    //Debug.Log(this.gameObject.GetComponentInChildren<MeshRenderer>().material);
    //}
}
