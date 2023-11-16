using System;
using System.Collections;
using System.IO;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public TMP_Text answer1Text;
    public TMP_Text answer2Text;
    public TMP_Text answer3Text;
    public TMP_Text answer4Text;

    //public GameObject Answer1;
    //public GameObject Answer2;
    //public GameObject Answer3;
    //public GameObject Answer4;

    public GameObject[] answers = new GameObject[4];


    public Vector2[] answerPositions = new Vector2[4];

    //public int answer1Value;
    //public int answer2Value;
    //public int answer3Value;
    //public int answer4Value;

    [HideInInspector] public static int[] answerValues = new int[4];

    private int[] correctAnswers = new int[4];

    private System.Random randX = new System.Random();
    private System.Random randY = new System.Random();

    private void Start()
    {
        for (int i = 0; i < QuestionSpawn.questions.GetLength(1); i++)
        {
            // creates correctAnswers using the 2d questions array in QuestionSpawn script
            correctAnswers[i] = int.Parse(QuestionSpawn.questions[1, i]);
        }

        for (int i = 0; i < answerPositions.GetLength(0); i++)
        {
            // adds random numbers to the answerPositions array with an x value in the range -35 to -65 
            // and y value in the range -3 to 0
            answerPositions[i] = new Vector2(randX.Next(-60, -40), randY.Next(-3, 0));
            answers[i].transform.position = answerPositions[i];
        }

        //Answer1.transform.position = answerPositions[0];
        //Answer2.transform.position = answerPositions[1];
        //Answer3.transform.position = answerPositions[2];
        //Answer4.transform.position = answerPositions[3];
               
    }
}
