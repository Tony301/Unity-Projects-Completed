using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCrazy : MonoBehaviour
{
    public Text scoreText;
    public Text HighScoreText;


    public float scoreAmountCrazy;
    public float HighScoreCount;

    public float pointsIncreasedPerSecond;
    public bool ScoreIncreasingCrazy;


    // Start is called before the first frame update
    void Start()
    {

       // if (PlayerPrefs.GetFloat("HighScoreCrazy") != null)
       // {
            HighScoreCount = PlayerPrefs.GetFloat("HighScoreCrazy");
       // }

    }

    // Update is called once per frame
    void Update()
    {

        if (ScoreIncreasingCrazy)
        {
            scoreAmountCrazy += pointsIncreasedPerSecond * Time.deltaTime;

        }

        if (scoreAmountCrazy > HighScoreCount)
        {
            HighScoreCount = scoreAmountCrazy;
            PlayerPrefs.SetFloat("HighScoreCrazy", HighScoreCount);
        }

        scoreText.text = Mathf.Round(scoreAmountCrazy) + " sec";
        HighScoreText.text = Mathf.Round(HighScoreCount) + " sec";

        // saveHighScoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString();




    }


    public void ResetScore()
    {
        scoreAmountCrazy = 0f;
    }
}
