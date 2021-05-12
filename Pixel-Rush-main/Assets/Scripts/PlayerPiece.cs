using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public Rigidbody PhysicalPart;
    public float RandForce;
    [HideInInspector] public bool WasLost;

    private SphereCollider sphereCollider;
    private Transform child;
    private PlayerController playerController;
    private float rand;



    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        sphereCollider = GetComponent<SphereCollider>();
        child = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Constants.ObstaclesLayerNumber)
        {
            WasLost = true;
            playerController.LostPeices.Add(this);
            PhysicalPart.gameObject.SetActive(true);
            sphereCollider.enabled = false;
            rand = Random.Range(-RandForce, RandForce);
            PhysicalPart.transform.position = child.position;
            PhysicalPart.AddForce(new Vector3(rand, rand, -Mathf.Abs(rand)), ForceMode.Impulse);
            child.gameObject.SetActive(false);
            playerController.UpdateLostPeicesCounter(-1);
        }
    }

    public void ResetPosition()
    {
        WasLost = false;
        sphereCollider.enabled = true;
        child.gameObject.SetActive(true);
        PhysicalPart.transform.position = child.position;
        PhysicalPart.gameObject.SetActive(false);
    }
}
