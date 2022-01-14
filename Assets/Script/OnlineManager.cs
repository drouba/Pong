using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineManager : MonoBehaviour
{
    public static OnlineManager instance;

    public GameObject playerPrefab, player2Prefab;
    public Transform spawnPt1, spawnPt2;
    private int nbPlayers;
    public GameObject ball;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.isOnline = true; 

        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            GameObject palet = PhotonNetwork.Instantiate(playerPrefab.name, spawnPt1.position, Quaternion.identity);
            palet.GetComponent<PlayerController>().isMine = true;
            PhotonView.Get(this).RPC("ready", RpcTarget.AllBuffered);
        }

        else
        {
            GameObject palet2 = PhotonNetwork.Instantiate(player2Prefab.name, spawnPt2.position, Quaternion.identity);
            palet2.GetComponent<PlayerController>().isMine = true;
            PhotonView.Get(this).RPC("ready", RpcTarget.AllBuffered);
            ball.GetComponent<BallBehaviour>().enabled = false;
        }
           
    }

    // Update is called once per frame
    void Update()
    {

    }



    [PunRPC]
    void ready()
    {
        nbPlayers++;
        if (nbPlayers == 2)
            GameManager.instance.started = true;

    }

    public void UpdatePlayer1Pts()
    {
        PhotonView.Get(this).RPC("ptsPlayer1", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void ptsPlayer1()
    {
        GameManager.instance.UpdatePlayerScore();
    }

    public void UpdatePlayer2Pts()
    {
        PhotonView.Get(this).RPC("ptsPlayer2", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void ptsPlayer2()
    {
        GameManager.instance.UpdateCpuScore();
    }

    public void SendOff()
    {
        PhotonView.Get(this).RPC("sendOffOnline", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void sendOffOnline()
    {
        GameManager.instance.sendOff = true;
    }
}
