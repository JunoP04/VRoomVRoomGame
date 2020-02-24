using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    public GameObject Bullet;
    //public Material newMat;
    public Material[] availableMat;
    public int currCol =0;
    // Start is called before the first frame update
    void Start()
    {
        createPlayer();
        
    }

    private void createPlayer()
    {
        Debug.Log("creating player" + currCol);
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        player.GetComponentInChildren<MeshRenderer>().material = availableMat[currCol];
        currCol++;

    }

}
