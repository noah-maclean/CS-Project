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

    private void Start()
    {
        studentScoresButton.onClick.AddListener(studentScoresClicked);
        addLoginsButton.onClick.AddListener(addLoginsClicked);
        removeLoginsButton.onClick.AddListener(removeLoginsClicked);
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
}
