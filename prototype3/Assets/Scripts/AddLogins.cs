using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AddLogins : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button addButton;
    public Button backButton;

    ArrayList credentials;

    private void Start()
    {
        addButton.onClick.AddListener(writeToFile);
        backButton.onClick.AddListener(backClicked);

        if (File.Exists(Application.dataPath + "/TextFiles/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/credentials.txt"));
        }
        else
        {
            //if file doesn't exist, create a credentials file
            File.WriteAllText(Application.dataPath + "/TextFiles/credentials.txt", "");
        }
    }

    void writeToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/credentials.txt"));

        //for every item in credentials, if the item contains the username, isExists = true
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        //if the user's details are already saved
        if (isExists)
        {
            Debug.Log($"User '{usernameInput.text}' already exists");
        }

        //if user's details don't exists 
        else
        {
            //user details are added to credentials array in the form username:password
            credentials.Add(usernameInput.text + ":" + passwordInput.text);

            //all lines of the credentials array are written to the credentials file
            File.WriteAllLines(Application.dataPath + "/TextFiles/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log($"User '{usernameInput.text}' added");
        }

        //resets the input fields to null
        usernameInput.text = null; 
        passwordInput.text = null;
    }

    void backClicked()
    {
        SceneManager.LoadScene("TeacherScreen");
    }
}
