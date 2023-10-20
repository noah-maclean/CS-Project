using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button LoginButton;

    private void Start()
    {
        //runs function "loginClicked" when the login button is pressed
        LoginButton.onClick.AddListener(loginClicked);
    }

    void loginClicked()
    {
        //loads the next scene (Login Screen)
        SceneManager.LoadScene("LoginScreen");
    }
}
