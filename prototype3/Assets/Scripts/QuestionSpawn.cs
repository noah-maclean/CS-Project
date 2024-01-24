using System.Collections;
using System.IO;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionSpawn : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;

    //location of question screen
    private Vector2 questionLocation = new Vector2(-50, 0);

    //location to return to after user completes question
    public static Vector2 returnLocation;

    public GameObject questionArea;

    // public TMP_Text questionLabel;
    // public TMP_Text questionText;
    // public TMP_InputField questionAnswer;
    // public Button submitButton;

    public TMP_Text questionText;

    //array containing the positions that the question area will appear in throughout the game
    //random positions could be implemented to make the game more varied
    //random positions could also be implemented for the platforms so that multiple environments wouldn't need to be made 
    [HideInInspector]
    public static Vector2[] questionAreaPositions = new[] { new Vector2 ( 4f, 0f ),
                                                            new Vector2 ( 33f, 0f ),
                                                            new Vector2 ( 60f, 0f ) };

    //2D array containing the questions and their answers
    //[HideInInspector] public static string[,] questions = new string[,] { { "What is 7 + 5?", "What is 9 + 1?", "What is 10 - 4?" }, 
    //{ "12", "10", "6" } };

    ArrayList questionData;
    public static string[,] questions = new string[2,3];

    public static int[] correctAnswers = new int[3];

    [HideInInspector] public int questionNum;
    //[HideInInspector] public int score;

    //GameObject overlay = GameObject.Find("OverlayCanvas");
    public GameObject overlayCanvas;
    public GameObject answersCanvas;

    public GameObject overlayPanel;
    public TMP_Text overlayTopic;

    //public bool questionActive;


    public void Start()
    {
        //initiates question number to 0
        questionNum = 0;

        //initiates score to 0
        //score = 0;

        //Debug.Log(questions.GetLength(0));
        //PlayerPrefs.SetInt("playerScore", 0);
        //PlayerPrefs.SetInt("remainingTime", 0);

        answersCanvas.SetActive(false);
        overlayPanel.SetActive(true);
        //overlayTopic = overlayCanvas.GetComponentInChildren<TMP_Text>();
        overlayTopic.enabled = true;

        if (File.Exists($"{Application.dataPath}/TextFiles/questionData.txt"))
        {
            questionData = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/questionData.txt"));
        }
        else
        {
            Debug.Log("Question data file doesn't exist");
        }

        //foreach var item{
        //if (item.ToString().Substring(0, item.ToString().IndexOf(":")).Equals(TutorialsScreen.tutorial))
        // add up to ; to questions array [0]
        // add from ; to end to questions array [1]
        // }

        int count = 0;
        foreach (var item in questionData)
        {
            if (item.ToString().Substring(0, item.ToString().IndexOf(":")).Equals(TopicsScreen.topic))
            {
                int index1 = item.ToString().IndexOf(":");
                int index2 = item.ToString().IndexOf(";");

                //takes the substring from the index after ":" with the length of (index2 - index1 - 1)
                questions[0, count] = item.ToString().Substring(index1 + 1, index2 - index1 - 1);
                questions[1, count] = item.ToString().Substring(index2 + 1, item.ToString().Length - index2 - 1);

                count++;
            }
        }

        for (int i = 0; i < questions.GetLength(1); i++)
        {
            correctAnswers[i] = int.Parse(questions[1, i]);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the game object that the player has collided with has the "Question" tag:
        if (collision.gameObject.tag == "Question")
        {
            //to allow the timer to be shown when the question is being answered
            //could set only certain parts of the overlayCanvas to false
            //(just the panel and the topic text)
            
            //overlayCanvas.SetActive(false);
            overlayPanel.SetActive(false);
            overlayTopic.enabled = false;
            
            answersCanvas.SetActive(true);

            Debug.Log($"Question {questionNum + 1}");

            returnLocation = transform.position;

            transform.position = questionLocation;

            //sets the question text at the top of the screen to be the current question
            questionText.text = questions[0, questionNum];

            //increments the question number 
            questionNum++;

            //moves questionArea to next position
            //questions.GetLength(0) returns 2 so must use <=
            if (questionNum <= questions.GetLength(0))
            {
                questionArea.transform.position = questionAreaPositions[questionNum];
            }

            else
            {
                questionArea.SetActive(false);
            }

        }

        //if the game object that the player has collided with has the "End" tag:
        else if (collision.gameObject.tag == "End")
        {
            //load the Game Over scene
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Update()
    {
        //questionText.transform.position = new Vector2(gameObject.transform.position.x, -10);
        questionText.GetComponent<RectTransform>().position = new Vector2(gameObject.transform.position.x, 4f);
    }
}
