using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public Vector2 limitX = new Vector2(-5f,5f);
    public Vector2 limitZ = new Vector2(-5f, 5f);
    public void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(limitX.x, limitX.y),1.05f, Random.Range(limitZ.x,limitZ.y));
        PhotonNetwork.Instantiate(playerPrefab.name,randomPosition,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
