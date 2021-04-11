using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Internal;

public class score : MonoBehaviour
{
    public Text timerText;
    public Text highscore;
    private float startTime;
    private bool finished = false;

    void GameFinished()
    {
        float t = Time.time - startTime;
        if (t < PlayerPrefs.GetFloat("HighScore", float.MaxValue))
        {
            PlayerPrefs.SetFloat("HighScore", t);
            highscore.text = t.ToString();
            PlayerPrefs.Save();
        }
    }

    void Start()
    {

        startTime = Time.time;
        highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }


    void Update()
    {

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("0");
        timerText.text = minutes + ":" + seconds;

       
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameFinished();

        }
    }
}







