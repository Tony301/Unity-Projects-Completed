using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

   // public float moveSpeed = 600f;

    //float movement = 0f;


    void Start()
    {
       // Button btn = left.GetComponent<Button>();
        //btn.onClick.AddListener(Left);


       // Button btn1 = right.GetComponent<Button>();
       // btn.onClick.AddListener(Right);
    }

   


    // Update is called once per frame
    void Update()
    {
       // movement = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
       // transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("end");
    }
}
