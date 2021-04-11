using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCrazy : MonoBehaviour
{
    public float ballSpeed;
    public bool turn = false;
    public float maxSpeed;

    public string currentColor;
    public SpriteRenderer sr;

    public Color colorBlack;
    public Color colorGrey;
    

    [SerializeField]
    private GameObject gameOverUI;

    private ScoreCrazy theScoreManagerCrazy;


    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
        theScoreManagerCrazy = FindObjectOfType<ScoreCrazy>();
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
            theScoreManagerCrazy.ScoreIncreasingCrazy = false;


            ballSpeed = 0.0f;
            gameOverUI.SetActive(true);
            theScoreManagerCrazy.scoreAmountCrazy = 0;
            theScoreManagerCrazy.ScoreIncreasingCrazy = false;

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
                currentColor = "Grey";
                sr.color = colorGrey;
                break;
           
            case 1:
                currentColor = "Black";
                sr.color = colorBlack;
                break;
        }
    }
}
