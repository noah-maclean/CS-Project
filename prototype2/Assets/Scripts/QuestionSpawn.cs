using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionSpawn : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;

    public GameObject question;
    public GameObject questionArea;

    [HideInInspector] public static bool questionActive;
    private int questionNum;

    public void Start()
    {
        //sets the question to not be visible when the game is started and initiates question number to 0
        question.SetActive(false);
        questionNum = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the game object that the player has collided with has the "Question" tag:
        if (collision.gameObject.tag == "Question")
        {
            questionActive = true;
            Debug.Log ( $"Question {questionNum + 1}!");

            //sets the question area and player to not be visible
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

            //sets the question to be visible
            question.SetActive(true);

            //increments the question number 
            questionNum++;

        }

        //if the game object that the player has collided with has the "End" tag:
        else if (collision.gameObject.tag == "End")
        {
            //load the Game Over scene
            SceneManager.LoadScene("GameOver");
        }
    }
}
