using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialsScreen : MonoBehaviour
{
    //creates a public string that can be accessed by other scripts
    public static string tutorial;

    public Button HowToPlayButton, TimesTableButton, PlaceValueButton, PercentagesButton, BidmasButton, FractionsButton, BackButton;
    private void Start()
    {
        //runs the corresponding function when the button is pressed
        HowToPlayButton.onClick.AddListener(howToPlayClicked);
        TimesTableButton.onClick.AddListener(timesTableClicked);
        PlaceValueButton.onClick.AddListener(placeValueClicked);
        PercentagesButton.onClick.AddListener(percentagesClicked);
        BidmasButton.onClick.AddListener(bidmasClicked);
        FractionsButton.onClick.AddListener(fractionsClicked);
        BackButton.onClick.AddListener(backClicked);
    }

    //each function sets the value of tutorial to the name of the function and loads the Tutorial scene
    private void howToPlayClicked()
    {
        tutorial = "How To Play";
        SceneManager.LoadScene("Tutorial");
    }

    private void timesTableClicked()
    {
        tutorial = "Times Table";
        SceneManager.LoadScene("Tutorial");
    }

    private void placeValueClicked()
    {
        tutorial = "Place Value";
        SceneManager.LoadScene("Tutorial");
    }

    private void percentagesClicked()
    {
        tutorial = "Percentages";
        SceneManager.LoadScene("Tutorial");
    }

    private void bidmasClicked()
    {
        tutorial = "Bidmas";
        SceneManager.LoadScene("Tutorial");
    }

    private void fractionsClicked()
    {
        tutorial = "Fractions";
        SceneManager.LoadScene("Tutorial"); 
    }


    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
}
