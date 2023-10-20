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
    public TMP_Text scoreText;
    public TMP_Text topicText;
    private static int score;
    [HideInInspector] public static string topic;
    [HideInInspector] public static bool questionActive;

    private void Update()
    {
        //NOT CURRENTLY WORKING
        //overlay dissapears during first question but doesn't return after question answered

        //if (QuestionSpawn.questionActive == true ) 
        //{
        //    gameObject.SetActive (false); 
        //}
        //else if (QuestionSpawn.questionActive == false )
        //{
        //    gameObject.SetActive (true);
        //}

        //score is updated as soon as score changes in the questionLogic script
        score = QuestionLogic.score;

        //displays the score on the screen
        scoreText.text = $"Score: {score}";
        
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

        //add timer to screen
        //if timer = 0, change to gameOver screen 
    }
}
