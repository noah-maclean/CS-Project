using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TeacherScript : MonoBehaviour
{
    public Button studentScoresButton;
    public Button addLoginsButton;
    public Button removeLoginsButton;
    public Button backButton;

    private void Start()
    {
        studentScoresButton.onClick.AddListener(studentScoresClicked);
        addLoginsButton.onClick.AddListener(addLoginsClicked);
        removeLoginsButton.onClick.AddListener(removeLoginsClicked);
        backButton.onClick.AddListener(backClicked);
    }

    void studentScoresClicked()
    {
        SceneManager.LoadScene("StudentScores");
    }

    void addLoginsClicked()
    {
        SceneManager.LoadScene("AddLogins");
    }

    void removeLoginsClicked()
    {
        SceneManager.LoadScene("RemoveLogins");
    }

    void backClicked()
    {
        SceneManager.LoadScene("LoginScreen");
    }
}
