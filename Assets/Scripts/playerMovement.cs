using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class playerMovement : MonoBehaviour
{
    public bool flagGround = false;
    public bool spawn = false;
    public Rigidbody rb;
    public GameObject cameraClient;
    float yRotate;
    public GameObject[] elementosAOcultar;
    public GameObject[] ojos;
    PhotonView view;
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
            Cursor.lockState = CursorLockMode.Locked;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("notForMe");
            foreach (GameObject eo in elementosAOcultar)
            {
                eo.layer = LayerIgnoreRaycast;
                if (eo.tag == "cabeza")
                {
                    eo.GetComponent<ballBehaviour>().enabled = true;
                    eo.tag = "Untagged";
                }
            }
            foreach (GameObject ojo in ojos)
            {
                ojo.layer = LayerIgnoreRaycast;
                ojo.tag = "Untagged";
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            float hori = -Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            float mHori = Input.GetAxisRaw("Mouse X");
            float mVert = -Input.GetAxisRaw("Mouse Y");

            rb.MovePosition(transform.position + (transform.forward * hori * Time.fixedDeltaTime * 5) + (transform.right * vert * Time.fixedDeltaTime * 5));
            if (Input.GetKey(KeyCode.Space) && flagGround)
            {
                flagGround = false;
                rb.velocity = new Vector3(rb.velocity.x, 7.5f, rb.velocity.z);
            }

            var p = transform;
            p.Rotate(0, mHori * 5f, 0);

            var c = transform.GetChild(0);

            yRotate += mVert * Time.fixedDeltaTime * 125f;
            yRotate = Mathf.Clamp(yRotate, -50f, 80f);
            c.eulerAngles = new Vector3(yRotate, c.eulerAngles.y, c.eulerAngles.z);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (view.IsMine && collision.transform.CompareTag("piso"))
        {
            flagGround = true;
        }
    }
}
