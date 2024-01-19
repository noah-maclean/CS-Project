using System;
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

    [SerializeField] public GameObject[] answers = new GameObject[numAnswers];


    public Vector2[] answerPositions = new Vector2[numAnswers];
    private Vector2 pos;

    public static int[] answerValues = new int[numAnswers];

    private int[] correctAnswers = new int[numAnswers];

    private System.Random randX = new System.Random();
    private System.Random randY = new System.Random();

    private System.Random randAns = new System.Random();
    private int correctAnsNum;
    private bool[] isCorrectAns = new bool[numAnswers];

    public GameObject hintPanel;
    public Button hintButton;
    private Button backButton;
    private TMP_Text hintText;


    //using a public gameobject allowed me to change whether the overlay was active or not
    //this removes the need for questionActive variable and trying to use GameObject.Find to get the object from another script
    public GameObject overlayCanvas;
    public GameObject answersCanvas;

    private void Start()
    {
        gameObject.SetActive(true);
        hintPanel.SetActive(false);

        backButton = hintPanel.GetComponentInChildren<Button>();
        hintButton.onClick.AddListener(hintClicked);
        backButton.onClick.AddListener(backClicked);

        //creates an array with the correct answers for each question
        for (int i = 0; i < QuestionSpawn.questions.GetLength(1); i++)
        {
            correctAnswers[i] = int.Parse(QuestionSpawn.questions[1, i]);
        }

        //chooses a random answer to be the correct answer by selecting an integer between 0 and 3
        correctAnsNum = randAns.Next(0, 3);

        changeAnsPosVal();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO - change to case statement

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
        }
        else
        {
            Debug.Log("Incorrect, try again");
            answers[num].SetActive(false);
            answersTexts[num].enabled = false;
        }
    }

    private void changeAnsPosVal()
    {
        if (GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum <= QuestionSpawn.questions.GetLength(0))
        {
            for (int i = 0; i < numAnswers; i++)
            {
                answers[i].SetActive(true);
                answersTexts[i].enabled = true;

                //pos is used as a temporary variable
                //change pos to int pos = new Vector2(UnityEngine.Random.Range(-60, -40), UnityEngine.Random.Range(-3, 0))
                pos = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));

                //if pos is in the answerPositions array, then a new pos value is generated
                //OR if pos is where the player spawns (x = -50)
                //while (pos.x == -50 || answerPositions.Contains(pos))
                //if position is between -52 and -48 (2 either side of 50 (the middle))
                while ((pos.x >= -52 && pos.x <= -48) || answerPositions.Contains(pos))
                {
                    pos = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));
                }

                // adds random numbers to the answerPositions array with an x value in the range -40 to -60 
                // and y value in the range -3 to 0
                answerPositions[i] = pos;

                //the positions of the answers and the texts are moved to the correct position
                answers[i].transform.position = answerPositions[i];
                answersTexts[i].GetComponent<RectTransform>().position = answerPositions[i];

                //creates an array with the answer values for the current question
                //creates duplicate answers often
                //TODO ensure that duplicate answers aren't created
                int val = UnityEngine.Random.Range(1, correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum] * 2);

                while (answerValues.Contains(val))
                {
                    val = UnityEngine.Random.Range(1, correctAnswers[GameObject.Find("Player").GetComponent<QuestionSpawn>().questionNum] * 2);
                }

                answerValues[i] = val;


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

    private void hintClicked()
    {
        hintPanel.SetActive(true);
        gameObject.SetActive(false);
        // add/change the hint text on the panel
    }

    private void backClicked()
    {
        hintPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
