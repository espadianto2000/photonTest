using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class simpleMovement : MonoBehaviour
{
    PhotonView view;
    public Rigidbody rb;
    public bool flagGround = false;
    public GameObject cameraClient;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            GameObject.Find("Main Camera").tag = "Untagged";
            GameObject.Find("Main Camera").SetActive(false);
            cameraClient.SetActive(true);
            cameraClient.tag = "MainCamera";
            cameraClient.GetComponent<AudioListener>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            float hori = -Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            float mHori = Input.GetAxisRaw("Mouse X");
            float mVert = -Input.GetAxisRaw("Mouse Y");

            rb.MovePosition(transform.position + (transform.forward * hori * 0.05f) + (transform.right * vert * 0.05f));
            if (Input.GetKey(KeyCode.Space) && flagGround)
            {
                flagGround = false;
                rb.velocity = new Vector3(rb.velocity.x, 7.5f, rb.velocity.z);
            }

            var p = transform;
            p.Rotate(0, mHori * 5f, 0);
        }
    }
}
