using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TutorialsLogic : MonoBehaviour
{
    [HideInInspector] public static string tutorial;

    public TMP_Text tutorialLabel;
    public TMP_Text tutorialInfo;
    public Button BackButton;


    ArrayList tutorialDetails;

    private void Start()
    {
        Debug.Log(TutorialsScreen.tutorial);

        //displays value of tutorial from the tutorialsScreen script 
        tutorialLabel.text = TutorialsScreen.tutorial.ToUpper();

        //runs the back function when back button is pressed
        BackButton.onClick.AddListener(backClicked);

        //want to have the tutorial details read from a file, like the login screen
        if (File.Exists($"{Application.dataPath}/TextFiles/tutorials.txt"))
        {
            //creates an array with the tutorial information from the file "tutorials.txt"
            tutorialDetails = new ArrayList(File.ReadAllLines($"{Application.dataPath}/TextFiles/tutorials.txt"));
            //Debug.Log(tutorialDetails.ToString());
        }
        else
        {
            //if file "tutorials.txt" doesn't exist, sends a debug message
            Debug.Log("Tutorials file doesn't exist");
        }



        //foreach (var item in tutorialDetails)
        //{
        //    bool isExists = false;
        //    if (item.ToString().Substring(0, item.ToString().IndexOf(":")).Equals(TutorialsScreen. tutorial))
        //    {
        //        tutorialInfo.text = item.ToString().Substring(item.ToString().IndexOf(":") + 1);
        //        isExists = true;
        //    }
        //    else
        //    {
        //        Debug.Log(isExists);
        //    }
        //}

        displayTutorialInfo();
    }


    void displayTutorialInfo()
    {
        //loops through each item in the tutorialDetails array (every line of the tutorials.txt file)
        foreach (var item in tutorialDetails)
        {
            //if the string before ":" is equal to the current tutorial:
            if (item.ToString().Substring(0, item.ToString().IndexOf(":")).Equals(TutorialsScreen.tutorial))
            {
                //the text on the screen is made the string after the ":"
                tutorialInfo.text = item.ToString().Substring(item.ToString().IndexOf(":") + 1);
            }
        }
    }

    void backClicked()
    {
        SceneManager.LoadScene("TutorialsScreen");
    }
}
