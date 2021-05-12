using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Photon.MonoBehaviour
{
    public float speed = 1f;
    public PhotonView photonView;
    public Rigidbody rb;
    public Animator anim;
    public GameObject PlayerCamera;
    public MeshRenderer sr;
    public Text PlayerNameText;

    public bool IsGrounded = false;
    public float MoveSpeed;
    public float JumpForce;

    private void Awake()
    {
        if(photonView.isMine)
        {
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;  

        }

        else
        {
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.white;
        }
    }

    private void Update()
    {
        if(photonView.isMine)
        {
            var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
            transform.position += move * MoveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                photonView.RPC("FlipA", PhotonTargets.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                photonView.RPC("FlipD", PhotonTargets.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                photonView.RPC("FlipS", PhotonTargets.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                photonView.RPC("FlipS", PhotonTargets.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                photonView.RPC("FlipR", PhotonTargets.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                photonView.RPC("FlipT", PhotonTargets.AllBuffered);
            }
        }
    }

   
    [PunRPC]
    private void FlipA()
    {
      
        sr.transform.position -= new Vector3( speed * Time.deltaTime,0,0);
    }

    [PunRPC]
    private void FlipD()
    {
      
        sr.transform.position += new Vector3( speed * Time.deltaTime,0,0);
    }

    private void FlipS()
    {
        sr.transform.position -= new Vector3(0,speed * Time.deltaTime,0);
    }

    [PunRPC]
    private void FlipW()
    {
        sr.transform.position += new Vector3( 0, speed * Time.deltaTime,0);
    }






    [PunRPC]

    private void FlipR()
    {
        sr.transform.Rotate(speed * Time.deltaTime, 0, 0);
    }

    [PunRPC]
    private void FlipT()
    {
        sr.transform.localScale -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
