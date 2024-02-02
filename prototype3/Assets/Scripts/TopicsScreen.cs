using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopicsScreen : MonoBehaviour
{
    public static string topic;
    public static string topicVal;
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
        topicVal = "timesTables";
        SceneManager.LoadScene("MainGame");
    }

    private void placeValueClicked()
    {
        topic = "Place Value";
        topicVal = "placeValue";
        SceneManager.LoadScene("MainGame");
    }

    private void percentagesClicked()
    {
        topic = "Percentages";
        topicVal = "percentages";
        SceneManager.LoadScene("MainGame");
    }

    private void bidmasClicked()
    {
        topic = "Bidmas";
        topicVal = "bidmas";
        SceneManager.LoadScene("MainGame");
    }

    private void fractionsClicked()
    {
        topic = "Fractions";
        topicVal = "fractions";
        SceneManager.LoadScene("MainGame");
    }

    private void timeClicked()
    {
        topic = "Time";
        topicVal = "time";
        SceneManager.LoadScene("MainGame");
    }

    private void backClicked()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
}
