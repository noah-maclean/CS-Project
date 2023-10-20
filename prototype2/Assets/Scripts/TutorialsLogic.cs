using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialsLogic : MonoBehaviour
{
    [HideInInspector] public static string tutorial;

    public TMP_Text tutorialText;

    private void Start()
    {
        //displays value of tutorial from the tutorialsScreen script 
        tutorialText.text = TutorialsScreen.tutorial.ToUpper();

        //want to have the tutorial details read from a file, like the login screen
    }
}
