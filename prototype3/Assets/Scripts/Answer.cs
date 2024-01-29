using System;
using System.IO;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class Answer : MonoBehaviour
{
    //holds the number of answers, allowing it to be changed
    static int numAnswers = 4;

    public TMP_Text[] answersTexts = new TMP_Text[numAnswers];

    public GameObject[] answers = new GameObject[numAnswers];


    public Vector2[] answerPositions = new Vector2[numAnswers];
    private Vector2 pos;

    public static float[] answerValues = new float[numAnswers];

    //private int[] correctAnswers = new int[numAnswers];

    private System.Random randX = new System.Random();
    private System.Random randY = new System.Random();

    private System.Random randAns = new System.Random();
    private int correctAnsNum;
    private bool[] isCorrectAns = new bool[numAnswers];
    private bool integerAns;

    public GameObject hintPanel;
    public Button hintButton;
    private Button backButton;
    public TMP_Text hintText;


    //using a public gameobject allowed me to change whether the overlay was active or not
    //this removes the need for questionActive variable and trying to use GameObject.Find to get the object from another script
    public GameObject overlayCanvas;
    public GameObject answersCanvas;

    public GameObject overlayPanel;
    public TMP_Text overlayTopic;

    public OverlayLogic overlayLogic;
    //public QuestionSpawn questionSpawn;

    
    private QuestionSpawn questionSpawnScript;

    private void Start()
    {
        //replaced GameObject.Find("Player").GetComponent<QuestionSpawn>() with a variable so that the Find and GetComponent functions will only need to be called once
        questionSpawnScript = GameObject.Find("Player").GetComponent<QuestionSpawn>();

        gameObject.SetActive(true);
        hintPanel.SetActive(false);

        backButton = hintPanel.GetComponentInChildren<Button>();
        hintButton.onClick.AddListener(hintClicked);
        backButton.onClick.AddListener(backClicked);

        //chooses a random answer to be the correct answer by selecting an integer between 0 and 3
        correctAnsNum = randAns.Next(0, 3);

        changeAnsPosVal();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO - change to switch statement?

        if (collision.gameObject == answers[0].gameObject)
        {
            isAnswerCorrect(0);
        }

        if (collision.gameObject == answers[1].gameObject)
        {
            isAnswerCorrect(1);
        }

        if (collision.gameObject == answers[2].gameObject)
        {
            isAnswerCorrect(2);
        }

        if (collision.gameObject == answers[3].gameObject)
        {
            isAnswerCorrect(3);
        }
    }

    private void isAnswerCorrect(int num)
    {
        if (isCorrectAns[num])
        {
            //if the answer is correct, output "Correct",
            //move the user to where they were before the questions
            //set the correct things to be visible
            //and change the positions and values of the answers based on the next question
            Debug.Log("Correct");
            transform.position = QuestionSpawn.returnLocation;
           
            overlayPanel.SetActive(true);
            overlayTopic.enabled = true;
            answersCanvas.SetActive(false);

            changeAnsPosVal();
        }
        else
        {
            //ig the answer is wrong, output "Incorrect (-15 seconds)"
            //remove that answer from the screen
            //take away 15 seconds from the user's time
            Debug.Log("Incorrect (-15 seconds)");
            answers[num].SetActive(false);
            answersTexts[num].enabled = false;
            overlayLogic.timeRemaining -= 15;
        }
    }

    //after making it so that questions and answers are stored in a text file
    //this function causes the game to not load at all
    //FIXED
    private void changeAnsPosVal()
    {
        
        if (questionSpawnScript.questionNum <= questionSpawnScript.questions.GetLength(0))
        {
            for (int i = 0; i < numAnswers; i++)
            {
                answers[i].SetActive(true);
                answersTexts[i].enabled = true;

                //pos is used as a temporary variable
                //change pos to int pos = new Vector2(UnityEngine.Random.Range(-60, -40), UnityEngine.Random.Range(-3, 0)) ??

                //changed y values to between -1 and 1, so that all the answers spawn above the user
                pos = new Vector2(randX.Next(-60, -40), randY.Next(-1, 1));

                //if pos is in the answerPositions array, then a new pos value is generated
                //OR if position is between -52 and -48 (2 either side of 50 (the middle))
                while ((pos.x >= -52 && pos.x <= -48) || answerPositions.Contains(pos))
                {
                    //pos = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));
                    //changed y values to between -1 and 0, so that all the answers spawn above the user
                    pos = new Vector2(randX.Next(-60, -40), randY.Next(-1, 1));
                }

                // adds random numbers to the answerPositions array with an x value in the range -40 to -60 
                // and y value in the range -3 to 0
                answerPositions[i] = pos;

                //the positions of the answers and the texts are moved to the correct position
                answers[i].transform.position = answerPositions[i];
                answersTexts[i].GetComponent<RectTransform>().position = answerPositions[i];


                //when answers were changed to a float to allow for decimals, all answers had lots of decimal points
                //to fix this I used rounding
                //if num is an integer, then num - Round(num) = 0, so it is an integer answer
                if (QuestionSpawn.correctAnswers[questionSpawnScript.questionNum] - Math.Round(QuestionSpawn.correctAnswers[questionSpawnScript.questionNum]) == 0)
                {
                    integerAns = true;
                }


                //creates an array with the answer values for the current question
                //creates duplicate answers often
                //TODO ensure that duplicate answers aren't created (DONE)

                //using round on val causes the percentages and fractions topics to not load

                float val = UnityEngine.Random.Range(1, QuestionSpawn.correctAnswers[questionSpawnScript.questionNum] * 2);
                if (integerAns)
                {
                    //while the temporary value is already in the array OR the value is the correct answer
                    while (answerValues.Contains((int)Math.Round(val)) || val == QuestionSpawn.correctAnswers[questionSpawnScript.questionNum])
                    {
                        //create a new random value
                        val = UnityEngine.Random.Range(1, QuestionSpawn.correctAnswers[questionSpawnScript.questionNum] * 2);
                    }
                }
                else
                {
                    //Contains cannot be used as it does not allow for float to be evaluated
                    //instead the Any function checks if any number - val is very small (almost 0)
                    while (answerValues.Any(num => Math.Abs(num - (float)Math.Round(val, 2)) < 0.01) || val == QuestionSpawn.correctAnswers[questionSpawnScript.questionNum])
                    {
                        val = UnityEngine.Random.Range(1, QuestionSpawn.correctAnswers[questionSpawnScript.questionNum] * 2);
                    }
                }         
                

                if (i == correctAnsNum)
                {
                    isCorrectAns[i] = true;

                    //if the answer is an integer, display the answer
                    if (integerAns)
                    {
                        answerValues[i] = QuestionSpawn.correctAnswers[questionSpawnScript.questionNum];
                    }
                    //if answer is not an integer, then round the value to 2 decimal places and make it a float
                    //so that it is in the same format as the other answers
                    else if (!integerAns)
                    {
                        answerValues[i] = (float)Math.Round(QuestionSpawn.correctAnswers[questionSpawnScript.questionNum], 2);
                    }
                }

                else
                {
                    isCorrectAns[i] = false;

                    //if the number is an integer, then round the value to no decimal places and make it an int
                    if (integerAns)
                    {
                        answerValues[i] = (int)Math.Round(val); 
                    }
                    //if number is not an integer, then round the value to 2 decimal places and make it a float
                    else if (!integerAns)
                    {
                        answerValues[i] = (float)Math.Round(val, 2);
                    }
                }

                answersTexts[i].text = answerValues[i].ToString();
            }
        }
    }

    private void hintClicked()
    {
        //make the hint text the information from the tutorial to give the user an explanation of how to solve the questions
        ArrayList hintDetails = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/tutorials.txt"));

        foreach (string line in hintDetails)
        {
            //if the string before ":" is equal to the current topic:
            if (line.Substring(0, line.IndexOf(":")).Equals(TopicsScreen.topic))
            {
                //the text on the screen is made the string after the ":"
                hintText.text = line.Substring(line.IndexOf(":") + 1);
            }
        }

        hintPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void backClicked()
    {
        hintPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
