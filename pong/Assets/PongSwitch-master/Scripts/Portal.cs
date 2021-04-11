using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private Transform destination;
    public bool isOrange;
    public float distance = 0.3f;
    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("UpperPortal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("LowerPortal").GetComponent<Transform>();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, collision.transform.position) > distance)
        {
            collision.transform.position = new Vector2(destination.position.x, destination.position.y);
        } 
    }

}


