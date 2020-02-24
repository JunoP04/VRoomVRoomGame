using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PaintCol : MonoBehaviourPunCallbacks
{
    public Material newMat;
    private PhotonView PV;

    private void Start()
    {
        newMat = this.gameObject.GetComponent<MeshRenderer>().material;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log(collision.gameObject);
        //PV.RPC("changeCol", RpcTarget.AllViaServer, this.gameObject);
        collision.gameObject.GetComponent<MeshRenderer>().material = newMat;
        PhotonNetwork.Destroy(this.gameObject);

    }
    [PunRPC]
    void changeCol(GameObject ob)
    {
        ob.GetComponentInChildren<MeshRenderer>().material = newMat;
        PhotonNetwork.Destroy(this.gameObject);
    }
    [PunRPC]
    void displayCol()
    {
        this.GetComponentInChildren<MeshRenderer>().material = newMat;
        Debug.Log(this.gameObject.GetComponentInChildren<MeshRenderer>().material);
    }
}
