using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuInput : MonoBehaviour
{

    EventSystem system;
    public Selectable firstInput;
    public Button submitButton;

    void Start()
    {
        //the first thing selected will be the username box
        system = EventSystem.current;
        firstInput.Select();
    }

    void Update()
    {
        //if tab and shift are pressed, then the previous box will be selected
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }

        //if only tab is pressed, then the next box will be selected
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }

        //if the enter key is pressed, the game will press the log in button
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            submitButton.onClick.Invoke();
        }
    }
}
