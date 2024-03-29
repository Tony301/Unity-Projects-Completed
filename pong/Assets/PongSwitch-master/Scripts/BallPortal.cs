﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPortal : MonoBehaviour
{

    public float ballSpeed;
    public bool turn = false;
    public float maxSpeed;

    public string currentColor;
    public SpriteRenderer sr;

    public Color colorBlack;
    public Color colorWhite;

    [SerializeField]
    private GameObject gameOverUI;

    private ScorePortal theScoreManagerPortal;


    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
        theScoreManagerPortal = FindObjectOfType<ScorePortal>();
    }



    // Update is called once per frame
    void Update()
    {
        if (ballSpeed < maxSpeed)
        {
            ballSpeed += 0.1f * Time.deltaTime;
        }

        if (!turn)
        {
            transform.Translate(0, ballSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, -ballSpeed * Time.deltaTime, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {


        if (collider.gameObject.tag == currentColor)
        {
            if (turn)
            {
                turn = false;

            }
            else
            {
                turn = true;

            }
        }

        if (collider.gameObject.tag != currentColor)
        {
            theScoreManagerPortal.ScoreIncreasingPortal = false;


            ballSpeed = 0.0f;
            gameOverUI.SetActive(true);
            theScoreManagerPortal.scoreCount = 0;
            theScoreManagerPortal.ScoreIncreasingPortal = false;

        }
    }





    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ColorChanger")
        {
            Debug.Log("Color Changing");
            SetRandomColor();
            return;
        }



    }

    public void SetRandomColor()
    {

        int index = UnityEngine.Random.Range(0, 2);

        switch (index)
        {
            case 0:
                currentColor = "Black";
                sr.color = colorBlack;
                break;
            case 1:
                currentColor = "White";
                sr.color = colorWhite;
                break;
        }
    }
}
