using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumber : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            if (other.GetComponent<PlayerPiece>().WasLost)
            {
                return;
            } 
            playerController.Jump();
        }
    }
}
