using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public Button TopicsButton, TutorialsButton;

    private void Start()
    {
        //runs function "topicsClicked" when the topics button is pressed
        TopicsButton.onClick.AddListener(topicsClicked);
        //runs function "tutorialsClicked" when tutorials button is pressed
        TutorialsButton.onClick.AddListener(tutorialsClicked);
    }

    void topicsClicked()
    {
        //loads Topics Screen scene
        SceneManager.LoadScene("TopicsScreen");
    }

    void tutorialsClicked()
    {
        //loads Tutorials Screen scene
        SceneManager.LoadScene("TutorialsScreen");
    }
}
