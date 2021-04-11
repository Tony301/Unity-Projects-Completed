using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorePortal : MonoBehaviour
{
    public Text scoreTextPortal;
    public Text HighScoreTextPortal;


    public float scoreCount;
    public float HighScoreCountPortal;

    public float pointsIncreasedPerSecond;
    public bool ScoreIncreasingPortal;


    // Start is called before the first frame update
    void Start()
    {

       // if (PlayerPrefs.GetFloat("HighScorePortal") != null)
        //{
            HighScoreCountPortal = PlayerPrefs.GetFloat("HighScorePortal");
       // }

    }

    // Update is called once per frame
    void Update()
    {

        if (ScoreIncreasingPortal)
        {
            scoreCount += pointsIncreasedPerSecond * Time.deltaTime;

        }

        if (scoreCount > HighScoreCountPortal)
        {
            HighScoreCountPortal = scoreCount;
            PlayerPrefs.SetFloat("HighScorePortal", HighScoreCountPortal);
        }

        scoreTextPortal.text = Mathf.Round(scoreCount) + " sec";
        HighScoreTextPortal.text = Mathf.Round(HighScoreCountPortal) + " sec";

        // saveHighScoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString();




    }


    public void ResetScore()
    {
        scoreCount = 0f;
    }
}
