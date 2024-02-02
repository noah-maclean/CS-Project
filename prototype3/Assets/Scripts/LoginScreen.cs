using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public Button LoginButton;

    ArrayList credentials;

    void Start()
    {
        //runs function "login" when the login button is pressed
        LoginButton.onClick.AddListener(login);

       
        if (File.Exists($"{Application.dataPath}/TextFiles/credentials.txt"))
        {
            //creates an array with the login details from the file "credentials.txt"
            credentials = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/credentials.txt"));
        }
        else
        {
           //if file "credentials.txt" doesn't exist, sends a debug message
            Debug.Log("Credentials file doesn't exist");
        }
    }

    void login()
    {
        bool isExists = false;
        bool isTeacher = false;

        //loops for every string (item) in the credentials file
        foreach (string i in credentials) //foreach (var i in credentials)
        {
            //makes a string 'line' with each item of the array
            //string line = i.ToString();

            //logins are written in form "username:password", so checks if the username input equals a valid username and same for password
            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(UsernameInput.text) &&
                i.ToString().Substring(i.ToString().IndexOf(":") + 1).Equals(PasswordInput.text))
            {
                //sets isExists to true and breaks out of the loop
                isExists = true;

                //if the username is "teacher", then isTeacher is set to true
                if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals("teacher"))
                {
                    isTeacher = true;
                }

                break;
            }
        }

        if (isExists && isTeacher)
        {
            //outputs "Logging in 'username'" and runs loadOptionsScreen function
            Debug.Log($"Logging in {UsernameInput.text}");
            loadTeacherScreen();
        }
        else if (isExists && !isTeacher)
        {
            //outputs "Logging in 'username'" and runs loadOptionsScreen function
            Debug.Log($"Logging in {UsernameInput.text}");

            //saves the username of the student
            PlayerPrefs.SetString("username", UsernameInput.text);
            loadOptionsScreen();
        }
        else
        {
            //outputs "Incorrect credentials"
            Debug.Log("Incorrect credentials");
        }
    }
    void loadOptionsScreen()
    {
        //loads the Options Screen scene
        SceneManager.LoadScene("OptionsScreen");
    }

    void loadTeacherScreen()
    {
        //loads the Teacher Screen scene
        SceneManager.LoadScene("TeacherScreen");
    }
}
