using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Answer : MonoBehaviour
{
    //holds the number of answers, allowing it to be changed
    static int numAnswers = 4;

    //public TMP_Text answer1Text;
    //public TMP_Text answer2Text;
    //public TMP_Text answer3Text;
    //public TMP_Text answer4Text;

    public TMP_Text[] answersTexts = new TMP_Text[numAnswers];

    //public GameObject Answer1;
    //public GameObject Answer2;
    //public GameObject Answer3;
    //public GameObject Answer4;

    [SerializeField] public GameObject[] answers = new GameObject[numAnswers];


    public Vector2[] answerPositions = new Vector2[numAnswers];
    private Vector2 pos;

    //public int answer1Value;
    //public int answer2Value;
    //public int answer3Value;
    //public int answer4Value;

    public static int[] answerValues = new int[numAnswers];

    private int[] correctAnswers = new int[numAnswers];

    private System.Random randX = new System.Random();
    private System.Random randY = new System.Random();

    private System.Random randAns = new System.Random();
    private int correctAnsNum;
    private bool[] isCorrectAns = new bool[numAnswers];

    //public bool questionActive;
    //GameObject overlay = GameObject.Find("OverlayCanvas");

    //using a public gameobject allowed me to change whether the overlay was active or not
    //this removes the need for questionActive variable and trying to use GameObject.Find to get the object from another script
    public GameObject overlayCanvas;
    public GameObject answersCanvas;

    private void Start()
    {
        //creates an array with the correct answers for each question
        for (int i = 0; i < QuestionSpawn.questions.GetLength(1); i++)
        {
            correctAnswers[i] = int.Parse(QuestionSpawn.questions[1, i]);
        }

        //chooses a random answer to be the correct answer by selecting an integer between 0 and 3
        correctAnsNum = randAns.Next(0, 3);

        for (int i = 0; i < numAnswers; i++)
        {
            // adds random numbers to the answerPositions array with an x value in the range -40 to -60 
            // and y value in the range -3 to 0
            pos = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));

            //if pos is in the answerPositions array, then a new pos value is generated
            //add OR if pos is where the player spawns (x = -50)
            //TODO fix OR operation
            while (pos.x == -50 || answerPositions.Contains(pos)) // || (pos.x = -50)
            {
                pos = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));
            }
            answerPositions[i] = pos;
            answers[i].transform.position = answerPositions[i];
            answersTexts[i].GetComponent<RectTransform>().position = answerPositions[i];

            //creates an array with the answer values for the current question
            //creates duplicate answers often
            //TODO ensure that duplicate answers aren't created
            answerValues[i] = randAns.Next(1, correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum] * 2);

            if (i == correctAnsNum)
            {
                isCorrectAns[i] = true;
                answerValues[i] = correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum];
            }

            else
            {
                isCorrectAns[i] = false;
            }

            //Debug.Log(answerValues[i].ToString());
            answersTexts[i].text = answerValues[i].ToString();
        }


        //for (int i = 0; i < numAnswers; i++)
        //{
        //   //creates an array with the answer values for the current question
        //    answerValues[i] = randAns.Next(1, correctAnswers[i] * 2);

        //    if (i == correctAnsNum)
        //    {
        //        isCorrectAns[i] = true;
        //        answerValues[i] = correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum];
        //    }

        //    else
        //    {
        //        isCorrectAns[i] = false;
        //    }

        //    Debug.Log(answerValues[i].ToString());
        //    answersTexts[i].text = answerValues[i].ToString();
        //}

        //Answer1.transform.position = answerPositions[0];
        //Answer2.transform.position = answerPositions[1];
        //Answer3.transform.position = answerPositions[2];
        //Answer4.transform.position = answerPositions[3];

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO - change to case statement

        if (collision.gameObject == answers[0].gameObject)
        {
            isAnswerCorrect(0);

            //changeAnsPosVal();
            //if (isCorrectAns[0])
            //{
            //    Debug.Log("Correct");
            //    transform.position = QuestionSpawn.returnLocation;
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().score += 100;

            //    //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum < QuestionSpawn.questions.GetLength(0))
            //    //{
            //    //    //move the question area to the next position
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.transform.position = QuestionSpawn.questionAreaPositions[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum + 1];

            //    //    //GameObject.Find("answers").GetComponent<Answer>()
            //    //    //increment the question number
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum++;
            //    //}
            //    //else
            //    //{
            //    //    //GameObject.Find("questionArea").SetActive(false); ;
            //    //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    //}

            //    if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum >= QuestionSpawn.questions.GetLength(0))
            //    {
            //        //sets the question area to false as there are no more questions
            //        GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    }
            //}
            //else
            //{
            //    Debug.Log("Incorrect, try again");
            //}
        }

        if (collision.gameObject == answers[1].gameObject)
        {
            isAnswerCorrect(1);

            //changeAnsPosVal();
            //if (isCorrectAns[1])
            //{
            //    Debug.Log("Correct");
            //    transform.position = QuestionSpawn.returnLocation;
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().score += 100;

            //    //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum < QuestionSpawn.questions.GetLength(0))
            //    //{
            //    //    //move the question area to the next position
            //    //    //gets the QuestionSpawn script from the player and uses it to reference the questionArea
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.transform.position = QuestionSpawn.questionAreaPositions[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum]; //+ 1

            //    //    //GameObject.Find("answers").GetComponent<Answer>()
            //    //    //increment the question number
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum++; 
            //    //}
            //    //else
            //    //{
            //    //    //GameObject.Find("questionArea").SetActive(false); ;
            //    //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    //}

            //    if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum >= QuestionSpawn.questions.GetLength(0))
            //    {
            //        //sets the question area to false as there are no more questions
            //        GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    }
            //}
            //else
            //{
            //    Debug.Log("Incorrect, try again");
            //}
        }

        if (collision.gameObject == answers[2].gameObject)
        {
            isAnswerCorrect(2);

            //changeAnsPosVal();
            //if (isCorrectAns[2])
            //{
            //    Debug.Log("Correct");
            //    transform.position = QuestionSpawn.returnLocation;
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().score += 100;

            //    //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum < QuestionSpawn.questions.GetLength(0))
            //    //{
            //    //    //move the question area to the next position
            //    //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.transform.position = QuestionSpawn.questionAreaPositions[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum /*+ 1*/];

            //    //    //GameObject.Find("answers").GetComponent<Answer>()
            //    //    //increment the question number
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum++;
            //    //}
            //    //else
            //    //{
            //    //    //GameObject.Find("questionArea").SetActive(false); ;
            //    //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    //}

            //    if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum >= QuestionSpawn.questions.GetLength(0))
            //    {
            //        //sets the question area to false as there are no more questions
            //        GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    }
            //}
            //else
            //{
            //    Debug.Log("Incorrect, try again");
            //}
        }

        if (collision.gameObject == answers[3].gameObject)
        {
            isAnswerCorrect(3);

            //if (isCorrectAns[3])
            //{
            //    Debug.Log("Correct");
            //    transform.position = QuestionSpawn.returnLocation;
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().score += 100;

            //    //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum <= QuestionSpawn.questions.GetLength(0))
            //    //{
            //    //    //move the question area to the next position
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.transform.position = QuestionSpawn.questionAreaPositions[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum/* + 1*/];

            //    //    //GameObject.Find("answers").GetComponent<Answer>()
            //    //    //increment the question number
            //    //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum++;
            //    //}
            //    //else
            //    //{
            //    //    //GameObject.Find("questionArea").SetActive(false); ;
            //    //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    //}

            //    if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum >= QuestionSpawn.questions.GetLength(0))
            //    {
            //        //sets the question area to false as there are no more questions
            //        GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //    }
            //}
            //else
            //{
            //    Debug.Log("Incorrect, try again");
            //}
        }
    }

    private void isAnswerCorrect(int num)
    {
        if (isCorrectAns[num])
        {
            Debug.Log("Correct");
            transform.position = QuestionSpawn.returnLocation;
            GameObject.Find("Player").GetComponent<QuestionSpawn>().score += 100;

            //sets the saved value of the score to the updated score
            PlayerPrefs.SetInt("playerScore", GameObject.Find("Player").GetComponent<QuestionSpawn>().score);

            //questionActive = false;

            //GameObject.Find("OverlayCanvas").SetActive(true);
            overlayCanvas.SetActive(true);
            answersCanvas.SetActive(false);

            changeAnsPosVal();

            //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum <= QuestionSpawn.questions.GetLength(0))
            //{
            //    //move the question area to the next position
            //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.transform.position = QuestionSpawn.questionAreaPositions[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum/* + 1*/];

            //    //GameObject.Find("answers").GetComponent<Answer>()
            //    //increment the question number
            //    //GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum++;
            //}
            //else
            //{
            //    //GameObject.Find("questionArea").SetActive(false); ;
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //}

            //if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum >= QuestionSpawn.questions.GetLength(0))
            //{
            //    //sets the question area to false as there are no more questions
            //    GameObject.Find("Player").GetComponent<QuestionSpawn>().questionArea.SetActive(false);
            //}
        }
        else
        {
            Debug.Log("Incorrect, try again");
        }
    }

    private void changeAnsPosVal()
    {
        if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum <= QuestionSpawn.questions.GetLength(0))
        {
            for (int i = 0; i < numAnswers; i++)
            {
                // adds random numbers to the answerPositions array with an x value in the range -40 to -60 
                // and y value in the range -3 to 0
                answerPositions[i] = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));
                answers[i].transform.position = answerPositions[i];
                answersTexts[i].GetComponent<RectTransform>().position = answerPositions[i];

                //creates an array with the answer values for the current question
                answerValues[i] = randAns.Next(1, correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum] * 2);

                if (i == correctAnsNum)
                {
                    isCorrectAns[i] = true;
                    answerValues[i] = correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum];
                }

                else
                {
                    isCorrectAns[i] = false;
                }

                //Debug.Log(answerValues[i].ToString());
                answersTexts[i].text = answerValues[i].ToString();
            }
        }
    }
}
