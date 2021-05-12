using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float RunningSpeed;
    public float JumpForce;
    public float HorizontalSmoothSpeed;
    public float MinYToReset;//lower point were the player lose if reached it
    public PlayerPiece[] PlayerPieces;
    public float SecondsToReset;
    [HideInInspector] public List<PlayerPiece> LostPeices = new List<PlayerPiece>();

    private Camera mainCamera;
    private Rigidbody rig;
    private bool isHoldingDown;
    private bool isJumbing;
    private Vector3 ignor;
    private Vector3 lastCheckPointPosition;//last chack point that the player reached
    private bool isGrounded;
    private int numOfLostPieces;
    private WaitForSeconds delay;
    private bool isDead;

    void Start()
    {
        delay = new WaitForSeconds(SecondsToReset);
        numOfLostPieces = 0;
        isGrounded = true;
        isJumbing = false;
        mainCamera = Camera.main;
        rig = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            isHoldingDown = true;

        }
        else
        {
            isHoldingDown = false;
        }

        if (transform.position.y < MinYToReset || numOfLostPieces == PlayerPieces.Length)
        {
            StartCoroutine(ResetAfterTime());
        }

        if (rig.velocity.y == 0 && isGrounded)
        {
            isJumbing = false;
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        if (isHoldingDown)
        {
            float mousePosX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane)).x;//get mouse world position on x axis(finger touch in mobile case)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(mousePosX, transform.position.y, transform.position.z), ref ignor, HorizontalSmoothSpeed * Time.deltaTime);//move the player somoothly to the mouse position
            rig.velocity = new Vector3(0, rig.velocity.y, RunningSpeed);//apply the running speed
        }
        else if (!isHoldingDown && !isJumbing)//stop moving forward whe the player is not holding down the mouse and the player is not jumbing
        {
            rig.velocity = new Vector3(0, rig.velocity.y, 0);
        }
    }

    public void Jump()
    {
        
        if (!isJumbing)
        {
            rig.velocity = Vector3.zero;//reset the velocity to prevent other forces from affecting the next jumping force
            isJumbing = true;
            isGrounded = false;
            rig.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);//apply jumping force
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.CheckPointTag))
        {
            lastCheckPointPosition = other.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Constants.GroundLayerNumber || collision.gameObject.layer == Constants.ObstaclesLayerNumber)
        {
            isGrounded = true;
        }
    }

    public void UpdateLostPeicesCounter(int num)
    {
        numOfLostPieces += num;
    }

    public IEnumerator ResetAfterTime()//reset player position and player peices after time
    {
        rig.velocity = Vector3.zero;
        isDead = true;
        rig.useGravity = false;
        numOfLostPieces = 0;
        isJumbing = false;

        yield return delay;

        foreach (PlayerPiece playerPiece in PlayerPieces)//inform all the palyer peices to reset their position
        {
            playerPiece.ResetPosition();
        }

        transform.position = new Vector3(lastCheckPointPosition.x,  lastCheckPointPosition.y + .5f, lastCheckPointPosition.z);//reset the player position to last check point position
        rig.useGravity = true;
        isDead = false;
    }
}
