using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class RemoveLogins : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public Button removeButton;
    public Button backButton;

    ArrayList credentials;
    private string toRemove;

    private void Start()    
    {
        removeButton.onClick.AddListener(removeFromFile);
        backButton.onClick.AddListener(backClicked);

        if (File.Exists(Application.dataPath + "/TextFiles/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/credentials.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/TextFiles/credentials.txt", "");
        }
    }

    void removeFromFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/TextFiles/credentials.txt"));

        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;

                //saves the current item in the toRemove variable
                toRemove = (string)i;
                break;
            }
        }

        if (isExists)
        {
            //remove
            credentials.Remove(toRemove);
            
            //ArrayList needs to be List<string> to use this function
            //credentials.RemoveAll(x => x.Contains(usernameInput.text));

            //uses a temporary file to save the lines that are kept
            var tempFile = Path.GetTempFileName();

            //keeps all lines where the item is not the one to remove
            var linesToKeep = File.ReadLines(Application.dataPath + "/TextFiles/credentials.txt").Where(x => x != toRemove);

            //writes all lines to keep to the temporary file
            File.WriteAllLines(tempFile, linesToKeep);

            //deletes the old credentials file
            File.Delete(Application.dataPath + "/TextFiles/credentials.txt");

            //copies the tempFile to a new credentials.txt file
            File.Move(tempFile, Application.dataPath + "/TextFiles/credentials.txt");
            Debug.Log($"User '{usernameInput.text}' removed");
        }
        else
        {
            //does not exist
            Debug.Log($"User '{usernameInput.text}' does not exist");
        }

        //resets the input field to null
        usernameInput.text = null;
    }

    void backClicked()
    {
        SceneManager.LoadScene("TeacherScreen");
    }
}
