using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 300;
    public GameObject Character;


    private Rigidbody2D CharacterBody;
    private float ScreenWidth;

    private void Start()
    {
        ScreenWidth = Screen.width;
        CharacterBody = Character.GetComponent<Rigidbody2D>();

    }

     void Update()
    {
        int i = 0;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                RunCharacterR(1.0f);
            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                RunCharacterL(-1.0f);
            }

            ++i;
        }
    }

    private void RunCharacterL(float horizontalInput)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward,  Time.fixedDeltaTime * moveSpeed);
    }

    private void RunCharacterR(float horizontalInput)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, Time.fixedDeltaTime * -moveSpeed);
    }
}
