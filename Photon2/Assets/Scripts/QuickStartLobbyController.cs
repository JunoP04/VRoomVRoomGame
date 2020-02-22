using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject quickStart;
    [SerializeField]
    private GameObject quickCancel;
    [SerializeField]
    private int roomSize;


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStart.SetActive(true);
    }

    public void quickStartGame()
    {
        quickStart.SetActive(false);
        quickCancel.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("quick join");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("no rooms exists");
        createRoom();
    }

    public void createRoom()
    {
        Debug.Log("created room");
        int randomRoomNo = Random.Range(0, 100);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize};
        PhotonNetwork.CreateRoom("room" + randomRoomNo, roomOps);
        Debug.Log(randomRoomNo);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("create room failed... retrying");
        createRoom();
    }

    public void Cancel()
    {
        quickCancel.SetActive(false);
        quickStart.SetActive(true);
        PhotonNetwork.LeaveRoom();


    }
    
}
