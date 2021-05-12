using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFillPeice : MonoBehaviour
{
    public float Speed;

    private bool hasToFill;
    private PlayerPiece peiceToFill;
    private Vector3 ignor;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasToFill)
        {
            if (Vector3.Distance(transform.position, peiceToFill.transform.position) > .1f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, peiceToFill.transform.position, ref ignor, Speed * Time.deltaTime);
            }
            else
            {
                hasToFill = false;
                playerController.LostPeices.Remove(peiceToFill);
                peiceToFill.ResetPosition();
                gameObject.SetActive(false);
                playerController.UpdateLostPeicesCounter(1);
            }
        }
    }

    public void Fill(PlayerPiece peiceToFill)
    {
        this.peiceToFill = peiceToFill;
        hasToFill = true;
    }
}
