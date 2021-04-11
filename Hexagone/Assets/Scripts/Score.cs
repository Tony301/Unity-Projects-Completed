using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public Text score;

    public Text highScore;

    public bool timerActive = true;

    public float timeTaken;

  //  public GameObject hitEffect;



    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();


       

    }

    // Update is called once per frame
    void Update()
    {


        if (timerActive)
        {
            timeTaken += Time.deltaTime;
            //timeTaken = timeTaken.
            score.text = timeTaken.ToString("0");
        }


        //int number =
        //score.text = number.ToString();

        if (timeTaken > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)timeTaken);
            highScore.text = timeTaken.ToString("0");
           // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        }
    }

    





}
