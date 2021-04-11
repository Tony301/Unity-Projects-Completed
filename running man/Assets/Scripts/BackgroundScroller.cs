using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;

   // public GameObject Platform; 
   // public GameObject Platform1;
   // public GameObject Platform2;






    private float width;
    private float scrollSpeed = -2f;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();


        width = collider.size.x;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
       ResetObstacle();
    }

     void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
           ResetObstacle();

        }
    }

    void ResetObstacle()
    {

       // Platform.transform.position = new Vector3(4, Random.Range(-2, 2), 0);
       // Platform.transform.position = new Vector3(0, Random.Range(-2, 2), 0);
       // Platform.transform.position = new Vector3(-4, Random.Range(-2, 2), 0);
         transform.GetChild(0).localPosition = new Vector3(Random.Range(-8, 8), Random.Range(-3, 3), 0);
    }
}

