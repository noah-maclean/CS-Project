using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

    private string username;
    ArrayList scoreData;

    private void Start()
    {
        //gets the score value from the saved int
        //score = PlayerPrefs.GetInt("playerScore");

        backButton.onClick.AddListener(backClicked);

        timeRemaining = PlayerPrefs.GetFloat("RemainingTime");
        username = PlayerPrefs.GetString("username");

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
        else if (timeRemaining > 30)
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

        saveUserScore();
        //scoreDescription.text = $"Your score was: {GameObject.Find("Player").GetComponent<QuestionSpawn>().score}/300";
        scoreDescription.text = $"Your score was: {score}/300";

        //GameObject.Find("Player").GetComponent<QuestionSpawn>().score.ToString()
    }

    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");        
    }

    void saveUserScore()
    {
        scoreData = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/studentScores.txt"));

        foreach (string i in scoreData)
        {
            if (i.Contains(username) && (int.Parse(i.Substring(i.IndexOf(":") + 1)) >= score))
            {
                break;
            }
            else if (i.Contains(username) && (int.Parse(i.Substring(i.IndexOf(":") + 1)) < score))
            {
                scoreData.Remove(i);
                scoreData.Add(username + ":" + score);
                File.WriteAllLines($"{Application.dataPath}/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(string)));
            }
            else if (!i.Contains(username))
            {
                scoreData.Add(username + ":" + score);

                File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(string)));
            }
        }
    }
}
