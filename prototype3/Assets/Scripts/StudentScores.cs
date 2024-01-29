using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StudentScores : MonoBehaviour
{
    //creates an arraylist that can be used to set the length of the studentScores array
    ArrayList arr = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/studentScores.txt"));

    string[] studentScores;
    string scoreData;
    public TMP_Text scoresText;

    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(backClicked);

        int count = 0;

        studentScores = new string[arr.Count];

        //adds the data from the file to an array as the string.join method needs an array not ArrayList
        foreach (string line in File.ReadLines(Application.dataPath + "/TextFiles/studentScores.txt"))
        {
            studentScores[count] = line;
            count++;
        }

        displayScores();
    }

    void displayScores()
    {
        //combines the data from studentScores with a line break after each item
        scoreData = String.Join("\n", studentScores);

        scoresText.text = scoreData;
    }

    void backClicked()
    {
        SceneManager.LoadScene("TeacherScreen");
    }
}
