using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialsLogic : MonoBehaviour
{
    [HideInInspector] public static string tutorial;

    public TMP_Text tutorialLabel, tutorialInfo;
    public Button BackButton;


    ArrayList tutorialDetails;

    private void Start()
    {
        //displays value of tutorial from the tutorialsScreen script 
        tutorialLabel.text = TutorialsScreen.tutorial.ToUpper();

        //runs the back function when back button is pressed
        BackButton.onClick.AddListener(backClicked);

        //want to have the tutorial details read from a file, like the login screen
        if (File.Exists($"{Application.dataPath}/TextFiles/tutorials.txt"))
        {
            //creates an array with the tutorial information from the file "tutorials.txt"
            tutorialDetails = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/tutorials.txt"));
        }
        else
        {
            //if file "tutorials.txt" doesn't exist, sends a debug message
            Debug.Log("Tutorials file doesn't exist");
        }

        displayTutorialInfo();
    }


    void displayTutorialInfo()
    {
        //loops through each item in the tutorialDetails array (every line of the tutorials.txt file)
        foreach (string item in tutorialDetails)
        {
            //if the string before ":" is equal to the current tutorial:
            if (item.Substring(0, item.IndexOf(":")).Equals(TutorialsScreen.tutorial))
            {
                //the text on the screen is made the string after the ":"
                tutorialInfo.text = item.Substring(item.IndexOf(":") + 1);
            }
        }
    }

    void backClicked()
    {
        SceneManager.LoadScene("TutorialsScreen");
    }
}
