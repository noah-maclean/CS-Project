using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopicsScreen : MonoBehaviour
{
    public static string topic;
    public Button TimesTableButton, PlaceValueButton, PercentagesButton, BidmasButton, FractionsButton, TimeButton, BackButton;
    private void Start()
    {
        //runs the corresponding function when the button is pressed
        TimesTableButton.onClick.AddListener(timesTableClicked);
        PlaceValueButton.onClick.AddListener(placeValueClicked);
        PercentagesButton.onClick.AddListener(percentagesClicked);
        BidmasButton.onClick.AddListener(bidmasClicked);
        FractionsButton.onClick.AddListener(fractionsClicked);
        TimeButton.onClick.AddListener(timeClicked);
        BackButton.onClick.AddListener(backClicked);
    }

    //each function sets the value of topic to the name of the function and loads the Main Game scene
    private void timesTableClicked()
    {
        topic = "Times Tables";
        SceneManager.LoadScene("MainGame");
    }

    private void placeValueClicked()
    {
        topic = "Place Value";
        SceneManager.LoadScene("MainGame");
    }

    private void percentagesClicked()
    {
        topic = "Percentages";
        SceneManager.LoadScene("MainGame");
    }

    private void bidmasClicked()
    {
        topic = "Bidmas";
        SceneManager.LoadScene("MainGame");
    }

    private void fractionsClicked()
    {
        topic = "Fractions";
        SceneManager.LoadScene("MainGame");
    }

    private void timeClicked()
    {
        topic = "Time";
        SceneManager.LoadScene("MainGame");
    }

    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
}
