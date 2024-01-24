using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    public TMP_Text gameOverLabel;
    public TMP_Text scoreDescription;
    public Button backButton;

    private int score;
    private float timeRemaining;

    private void Start()
    {
        //gets the score value from the saved int
        //score = PlayerPrefs.GetInt("playerScore");

        backButton.onClick.AddListener(backClicked);

        timeRemaining = PlayerPrefs.GetFloat("RemainingTime");

        //total score = 300
        //score cannot be accessed as the Player object is not in the game over scene, so it cannot be found
        //PlayerPrefs could be used to solve this issue
        //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().score > 200)
        //if (score > 200)
        if (timeRemaining > 60 )
        {
            gameOverLabel.text = "Congratulations!";
            //score = (int)System.Math.Round(timeRemaining * 3.33f, 0);
        }
        //else if (GameObject.Find("Player").GetComponent<QuestionSpawn>().score > 100)
        else if (timeRemaining > 45)
        {
            gameOverLabel.text = "Well done!";
            //score = (int)System.Math.Round(timeRemaining * 3.33f, 0);
        }
        else
        {
            gameOverLabel.text = "Unlucky, try again";
            //score = (int)System.Math.Round(timeRemaining * 3.33f, 0);
        }

        score = (int)System.Math.Round(timeRemaining * 5, 0);

        if (score > 300)
        {
            score = 300; 
        }
        
        //scoreDescription.text = $"Your score was: {GameObject.Find("Player").GetComponent<QuestionSpawn>().score}/300";
        scoreDescription.text = $"Your score was: {score}/300";

        //GameObject.Find("Player").GetComponent<QuestionSpawn>().score.ToString()
    }

    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");        
    }
}
