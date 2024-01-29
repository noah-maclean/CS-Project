using System;
using System.Collections;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverlayLogic : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text topicText;

    //timeRemaining in seconds
    [HideInInspector] public float timeRemaining = 90;
    [HideInInspector] public static string topic;

    public GameObject overlayCanvas;    

    private void Start()
    {
        overlayCanvas.SetActive(true);
    }

    private void Update()
    {
        //if there is a topic:
        if (TopicsScreen.topic != null )
        {
            //topic text is the value of topic in uppercase
            topicText.text = TopicsScreen.topic.ToUpper();
        }
        else
        {
            //if there is no value for the topic, displays that message
            //needed as error would be produced if game was started without going through options screen
            topicText.text = "Test/Error (no topic)";
        }

        if (timeRemaining > 0)
        {
            //if their is time remaining then decrease the time
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            loadGameOver();
        }

        displayTime();

        //saves the timeRemaining on every frame, so that if the user completes the game
        //then their remaining time is already saved
        PlayerPrefs.SetFloat("RemainingTime", timeRemaining);
    }

    private void displayTime()
    {
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
        }

        //mins = time remaining divided by 60 and rounded down to an integer 
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        //secs = time remaining mod 60 and rounded down to an int
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        //displays the time in the correct format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");
        PlayerPrefs.SetFloat("RemainingTime", timeRemaining);
    }
}
