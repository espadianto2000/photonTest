using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ballBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<PhotonView>().IsMine)
        {
            GameObject[] ojos = GameObject.FindGameObjectsWithTag("ojo");
            foreach (GameObject ojo in ojos)
            {
                ojo.transform.LookAt(transform.position);
            }
        }
        /*GameObject[] ojos = GameObject.FindGameObjectsWithTag("ojo");
        foreach (GameObject ojo in ojos)
        {
            ojo.transform.LookAt(transform.position);
        }*/
    }
}
