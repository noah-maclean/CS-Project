using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public Button topicsButton, tutorialsButton, backButton;

    private void Start()
    {
        //runs function "topicsClicked" when the topics button is pressed
        topicsButton.onClick.AddListener(topicsClicked);
        //runs function "tutorialsClicked" when tutorials button is pressed
        tutorialsButton.onClick.AddListener(tutorialsClicked);
        backButton.onClick.AddListener(backClicked);
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

    void backClicked()
    {
        SceneManager.LoadScene("LoginScreen");
    }
}
