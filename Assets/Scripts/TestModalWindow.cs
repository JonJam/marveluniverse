using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour
{
    private ModalPanel modalPanel;

    private DisplayManager displayManager;


    private void Awake()
    {
        this.modalPanel = ModalPanel.Instance();
        this.displayManager = DisplayManager.Instance();
    }

    public void TestYNC()
    {
        ModalPanelDetails panelDetails = new ModalPanelDetails()
        {
            Title = "This is the title",
            Message = "This is an announcement",
            Button1Details = new EventButtonDetails()
            {
                ButtonTitle = "Yes",
                Action = this.TestYesFunction
            },
            Button2Details = new EventButtonDetails()
            {
                ButtonTitle = "No",
                Action = this.TestNoFunction
            },
            Button3Details = new EventButtonDetails()
            {
                ButtonTitle = "Cancel",
                Action = this.TestCancelFunction
            }
        };

        this.modalPanel.NewChoice(panelDetails);
    }


    private void TestYesFunction()
    {
        this.displayManager.DisplayMessage("Heck yeah! Yup!");
    }

    private void TestNoFunction()
    {
        this.displayManager.DisplayMessage("Heck no! No!");
    }

    private void TestCancelFunction()
    {
        this.displayManager.DisplayMessage("Cancelled.");
    }
}
