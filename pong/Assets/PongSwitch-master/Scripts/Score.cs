using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text HighScoreText;
    

    public float scoreAmount;
    public float HighScoreCount;

    public float pointsIncreasedPerSecond;
    public bool ScoreIncreasing;

  
    // Start is called before the first frame update
    void Start()
    {
        
      // if(PlayerPrefs.GetFloat("HighScore")!=null)
       // {
            HighScoreCount = PlayerPrefs.GetFloat("HighScore");
        //}
      
    }

    // Update is called once per frame
    void Update()
    {

        if(ScoreIncreasing)
        {
            scoreAmount += pointsIncreasedPerSecond * Time.deltaTime;
            
        }

        if(scoreAmount > HighScoreCount)
        {
            HighScoreCount = scoreAmount;
            PlayerPrefs.SetFloat("HighScore",HighScoreCount);
        }

        scoreText.text = Mathf.Round(scoreAmount)+" sec";
        HighScoreText.text = Mathf.Round(HighScoreCount) + " sec";
       
       // saveHighScoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString();


        
       
    }

    
    public void ResetScore()
    {
        scoreAmount = 0f;
    }
}
