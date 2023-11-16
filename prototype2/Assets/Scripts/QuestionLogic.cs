using System;
using System.Collections;
using System.IO;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionLogic : MonoBehaviour
{
    public TMP_Text questionLabel;
    public TMP_Text questionText;
    public TMP_InputField questionAnswer;
    public Button submitButton;
    public GameObject player;
    public GameObject questionArea;

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

    private void Start()
    {
        //runs the "answer" function when the Submit button is clicked
        //submitButton.onClick.AddListener(answer);
        questionNum = 0;
        
        //changes the text on the question to reflect the current question
        //questionLabel.text = $"Question {questionNum + 1}";
        //questionText.text = questions[0, questionNum];

        //questionText.text = questions[0, random.Range[0,2];
        //make the question that appears random?
        //probably need to make the random number a variable so that it can be used to find the answer

        score = 0;
    }


    void answer()
    {
        //if the inputted answer is equal to the answer in the array:
        if (questionAnswer.text == questions[1,questionNum])
        {
            //changes the questionActive variable from the questionSpawn script to false
            //CURRENTLY DOESN'T WORK
            QuestionSpawn.questionActive = false;

            //outputs "Correct answer!"
            Debug.Log ( "Correct answer!" );

            //sets the question to not be visible
            gameObject.SetActive ( false );

            //sets the player and the question area to be visible
            player.SetActive ( true );
            questionArea.SetActive ( true );

            //moves the player back to the position they were in when they hit the question area
            player.transform.position = QuestionSpawn.returnLocation;

            //adds 100 to the score
            score += 100;

            //removes the previous answer from the input box
            questionAnswer.text = null;

            //if the question number is less than the number of questions:
            if (questionNum < questions.GetLength(0))
            {
                //move the question area to the next position
                questionArea.transform.position = questionAreaPositions[questionNum + 1];

                //increment the question number
                questionNum++;

                //change the question text to reflect the new question
                //questionLabel.text = $"Question {questionNum + 1}";
                //questionText.text = questions[0, questionNum];
            }

            else
            {
                //if the question number is equal to the number of questions, then the number is not increased
                //sets question and question area to not be visible
                questionArea.SetActive( false );
                gameObject.SetActive( false );

                //sets player to be visible
                player.SetActive( true );
            }
        }

        else
        {
            Debug.Log ( "Incorrect!" );
        }
    }

 }
