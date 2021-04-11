using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pMove : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;


    private bool grounded;
   
    public LayerMask whatIsGround;

    private Collider2D myCollider;


    private Animator myAnimator;



   
   
   
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);



        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }



        myAnimator.SetFloat("speed", myRigidbody.velocity.x);

        myAnimator.SetBool("grounded", grounded);
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
