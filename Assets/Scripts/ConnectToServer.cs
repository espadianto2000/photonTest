using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void conectar()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("conectando");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("conectado a master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("unido a lobby");
        SceneManager.LoadScene("Lobby",LoadSceneMode.Single);
    }
    public void ingresar()
    {
        conectar();
    }

}
