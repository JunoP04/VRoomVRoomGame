using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("joined Room");
        startGame();
    }
    private void startGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("starting game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }
}
