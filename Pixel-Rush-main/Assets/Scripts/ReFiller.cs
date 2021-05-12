using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFiller : MonoBehaviour
{
    public ReFillPeice[] ReFillPeices;

    private PlayerController playerController;
    private int counter;
    private bool isFilling;

    private void Start()
    {
        counter = 0;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFilling)
        {
            return;
        }

        if (other.CompareTag(Constants.PlayerTag))
        {
            isFilling = true;

            foreach (ReFillPeice reFillPeice in ReFillPeices)//fill all the lost peices
            {
                if (playerController != null)
                {
                    if (playerController.LostPeices.Count > 0 && counter < playerController.LostPeices.Count)
                    {

                        reFillPeice.Fill(playerController.LostPeices[counter]);
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        playerController.transform.position += Vector3.up * 1f;//to prevent the player from getting stuck inside the ground
    }
}
