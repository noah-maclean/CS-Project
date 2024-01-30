using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    public TMP_Text gameOverLabel, scoreDescription;
    public Button backButton;

    private int score;
    private float timeRemaining;

    private string username;
    ArrayList scoreData;

    bool containsUser, newHighScore, isTopicCurrent;
    string temp;


    private void Start()
    {
        //gets the score value from the saved int
        //score = PlayerPrefs.GetInt("playerScore");

        backButton.onClick.AddListener(backClicked);

        timeRemaining = PlayerPrefs.GetFloat("RemainingTime");
        username = PlayerPrefs.GetString("username");

        //total score = 300
        //timeremaining cannot be accessed as the Player object is not in the game over scene, so it cannot be found
        //PlayerPrefs could be used to solve this issue
        if (timeRemaining > 60)
        {
            gameOverLabel.text = "Congratulations!";
        }

        else if (timeRemaining > 30)
        {
            gameOverLabel.text = "Well done!";
        }

        else
        {
            gameOverLabel.text = "Unlucky, try again";
        }

        score = (int)System.Math.Round(timeRemaining * 5, 0);

        if (score > 300)
        {
            score = 300;
        }

        saveUserScore();

        scoreDescription.text = $"Your score was: {score}/300";
    }

    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    void saveUserScore()
    {
        scoreData = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/studentScores.txt"));

        foreach (string line in scoreData)
        {
            int currentHighScore = int.Parse(line[(line.IndexOf(":") + 1)..]);

            //if the user has already got a saved score:
            if (line.Contains(username))
            {
                containsUser = true;

                //if the score that is being saved is the same topic as the score that is already saved:
                if (line.Contains(TopicsScreen.topic))
                {
                    isTopicCurrent = true;

                    //if current score is not higher than their previous score then don't save score
                    if (currentHighScore >= score)
                    {
                        //Debug.Log("score not higher");
                        newHighScore = false;
                        break;
                    }
                    //if current score is higher than the previous score then save the score
                    else
                    {
                        //Debug.Log("new high score");
                        newHighScore = true;
                        temp = line;
                        break;
                    }
                }
                else
                {
                    //if the topic in this string is not the samme as the topic to be saved then continue the loop
                    isTopicCurrent = false;
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
            //if the user already has a score with the same topic that is lower than their new score:
            if (newHighScore)
            {
                //remove the old score and add the new score
                scoreData.Remove(temp);
                scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
            }
        }
        //else if the user doesn't already have a saved score at all or for this topic:
        else
        {
            //add their new score
            scoreData.Add($"{username}-{TopicsScreen.topic}:{score}");
        }

        File.WriteAllLines(Application.dataPath + "/TextFiles/studentScores.txt", (string[])scoreData.ToArray(typeof(string)));
    }
}
