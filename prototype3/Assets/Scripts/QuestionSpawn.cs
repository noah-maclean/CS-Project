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
    [HideInInspector] public static string[,] questions = new string[,] { { "What is 7 + 5?", "What is 9 + 1?", "What is 10 - 4?" }, 
                                                                          { "12", "10", "6" } };

    [HideInInspector] public int questionNum;
    [HideInInspector] public int score;

    //GameObject overlay = GameObject.Find("OverlayCanvas");
    public GameObject overlayCanvas;
    public GameObject answersCanvas;

    //public bool questionActive;


    public void Start()
    {
        //initiates question number to 0
        questionNum = 0;

        //initiates score to 0
        score = 0;

        //Debug.Log(questions.GetLength(0));
        //PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("remainingTime", 0);

        answersCanvas.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the game object that the player has collided with has the "Question" tag:
        if (collision.gameObject.tag == "Question")
        {
            
            overlayCanvas.SetActive(false);
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
