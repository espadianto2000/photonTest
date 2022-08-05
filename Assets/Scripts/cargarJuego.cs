using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon;

public class cargarJuego : MonoBehaviourPunCallbacks
{
    GameObject[] eliminar;
    public GameObject playerPrefab;
    public Vector2 limitX = new Vector2(-5f, 5f);
    public Vector2 limitZ = new Vector2(-5f, 5f);
    public void crear()
    {
        PhotonNetwork.CreateRoom("a");
    }
    public void unirse()
    {
        PhotonNetwork.JoinRoom("a");
    }
    public override void OnJoinedRoom()
    {
        //SceneManager.LoadScene("Juego",LoadSceneMode.Single);
        Vector3 randomPosition = new Vector3(Random.Range(limitX.x, limitX.y), 1.05f, Random.Range(limitZ.x, limitZ.y));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        transform.gameObject.SetActive(false);
    }
}
