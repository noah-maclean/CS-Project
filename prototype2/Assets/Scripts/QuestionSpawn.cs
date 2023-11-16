using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionSpawn : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    
    //location of question screen
    private Vector2 questionLocation = new Vector2(-50, 0);

    //location to return to after user completes question
    public static Vector2 returnLocation;

    public GameObject questionArea;
    public TMP_Text questionLabel;
    public TMP_Text questionText;
    public TMP_InputField questionAnswer;
    public Button submitButton;

    //array containing the positions that the question area will appear in throughout the game
    //random positions could be implemented to make the game more varied
    //random positions could also be implemented for the platforms so that multiple environments wouldn't need to be made 
    private Vector2[] questionAreaPositions = new[] { new Vector2 ( 4f, 0f ) ,
                                           new Vector2 ( 33f, 0f ),
                                           new Vector2 ( 60f, 0f) };

    //2D array containing the questions and their answers
    [HideInInspector] public static string[,] questions = new string[,] { { "What is 7 + 5?", "What is 9 + 1?", "What is 10 - 4?" }, { "12", "10", "6" } };

    [HideInInspector] public static int questionNum;
    [HideInInspector] public static int score;
    //[HideInInspector] public static bool questionActive;

    [HideInInspector] public static bool questionActive;

    public void Start()
    {
        //initiates question number to 0
        questionNum = 0;

        //initiates score to 0
        score = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the game object that the player has collided with has the "Question" tag:
        if (collision.gameObject.tag == "Question")
        {
            questionActive = true;
            Debug.Log ( $"Question {questionNum + 1}!");

            //sets the question area and player to not be visible
            //collision.gameObject.SetActive(false);
            //gameObject.SetActive(false);

            //sets the question to be visible
            //question.SetActive(true);

            returnLocation = transform.position;

            transform.position = questionLocation;

            //increments the question number 
            questionNum++;

        }

        //if the game object that the player has collided with has the "End" tag:
        else if (collision.gameObject.tag == "End")
        {
            //load the Game Over scene
            SceneManager.LoadScene("GameOver");
        }

        //if the game object that the player collides with is an answer:
        else if (collision.gameObject.tag == "Answer")
        {
            if (collision.gameObject.name == "Answer1")
            {

            }

            else if (collision.gameObject.name == "Answer2")
            {

            }

            else if (collision.gameObject.name == "Answer3") ;
        }
    }
}
