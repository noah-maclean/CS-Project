using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeacherScript : MonoBehaviour
{
    public Button studentScoresButton, addLoginsButton, removeLoginsButton, backButton;

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
