using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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

    bool containsUser;
    bool newHighScore;
    bool isTopicCurrent;
    string temp;
    

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
        //this works to add an item to the array, but does not remove the old score
        //scoreData = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/studentScores.txt"))
        //{
        //    $"{username} - {TopicsScreen.topic}:{score}"
        //};
        //File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(String)));
        //Debug.Log("Score saved");

        scoreData = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/studentScores.txt"));

        //doesn't work
        //if (scoreData.Contains(username))
        
        //does work
        //if (scoreData.Contains("noah - Times Tables:228"))
        //{
        //    Debug.Log("user already played");
        //    foreach (string line in scoreData)
        //    {
        //        int currentHighScore = int.Parse(line[(line.IndexOf(":") + 1)..]);
        //        Debug.Log(currentHighScore);

        //        if (line.Contains(username))
        //        {
        //            if (currentHighScore >= score)
        //            {
        //                break;
        //            }
        //            else
        //            {
        //                scoreData.Remove(line);
        //                scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
        //}

        foreach (string line in scoreData)
        {
            int currentHighScore = int.Parse(line[(line.IndexOf(":") + 1)..]);
            Debug.Log(currentHighScore);
            if (line.Contains(username))
            {
                containsUser = true;
                
                //Debug.Log($"{line} contains username");
                //Debug.Log(line.Substring(line.IndexOf("-") + 1, line.IndexOf(":") - line.IndexOf("-") - 1));

                if (line.Substring(line.IndexOf("-") + 1, line.IndexOf(":") - line.IndexOf("-") - 1) == TopicsScreen.topic)
                //if (line.Contains(TopicsScreen.topic))
                {
                    isTopicCurrent = true;
                    if (currentHighScore >= score)
                    {
                        Debug.Log("score not higher");
                        newHighScore = false;
                        break;
                    }
                    else
                    {
                        Debug.Log("new high score");
                        newHighScore = true;
                        temp = line;
                        break;
                    }
                }
                else
                {
                    //isTopicCurrent = false;
                    //temp = line;
                    isTopicCurrent= false;
                    continue;
                }
            }
            else
            {
                containsUser = false;
                temp = line;
            }
        }

        if (containsUser && isTopicCurrent)
        {
            if (newHighScore)
            {
                scoreData.Remove(temp);
                scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
            }
        }
        else
        {
            scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
        }

        File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (string[])scoreData.ToArray(typeof(string)));



        //foreach (var i in scoreData)
        //{
        //    int userHighScore = int.Parse(i.ToString()[(i.ToString().IndexOf(":") + 1)..]);
        //    Debug.Log(userHighScore);

        ////    if (i.ToString().Contains(username) && (int.Parse(i.ToString().Substring(i.ToString().IndexOf(":") + 1)) >= score))
        ////    FormatException: Input string was not in a correct format.
        //    if (i.ToString().Contains(username) && userHighScore >= score)
        //    {
        //        break;
        //    }
        //    else if (i.ToString().Contains(username) && (int.Parse(i.ToString().Substring(i.ToString().IndexOf(":") + 1)) < score))
        //    else if (i.ToString().Contains(username) && userHighScore < score)
        //            {
        //                scoreData.Remove(i);
        //                scoreData.Add(username + ":" + score);
        //                File.WriteAllLines($"{Application.dataPath}/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(string)));
        //                File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(String)));
        //                Debug.Log("score saved");
        //            }
        //            else
        //            {
        //                scoreData.Add(username + ":" + score);

        //                File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (String[])scoreData.ToArray(typeof(String)));
        //                Debug.Log("score saved");
        //            }
        //}
    }
}
