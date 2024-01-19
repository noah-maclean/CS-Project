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
    //[HideInInspector] public bool questionActive;

    public GameObject overlayCanvas;

    

    private void Start()
    {
        //GameObject.Find("Player").GetComponent<Answer>().questionActive = false;
        //gameObject.SetActive(true);
        overlayCanvas.SetActive(true);
    }

    private void Update()
    {
        //score is updated as soon as score changes in the questionLogic script
        score = GameObject.Find("Player").GetComponent<QuestionSpawn>().score;

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
