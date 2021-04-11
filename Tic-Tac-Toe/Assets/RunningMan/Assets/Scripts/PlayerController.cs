using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);  
    }
    void Update()
    {

        if(isGrounded == true)
        {
            extraJumps = 2;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps>0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) == extraJumps > 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


        float moveDirection = Input.GetAxisRaw("Vertical");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("end");
            Destroy(gameObject);
            SceneManager.LoadScene("retry");
        }
    }


}
