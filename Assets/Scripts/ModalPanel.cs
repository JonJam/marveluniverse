using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventButtonDetails
{
    public string ButtonTitle;
    public UnityAction Action;
}

public class ModalPanelDetails
{
    public string Title;
    public string Message;
    public EventButtonDetails Button1Details;
    public EventButtonDetails Button2Details;
    public EventButtonDetails Button3Details;
}

public class ModalPanel : MonoBehaviour
{
    public Text Title;
    public Text Message;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public GameObject ModalPanelObject;

    public Text Button1Text;
    public Text Button2Text;
    public Text Button3Text;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!ModalPanel.modalPanel)
        {
            ModalPanel.modalPanel = Object.FindObjectOfType<ModalPanel>();

            if (!ModalPanel.modalPanel)
            {
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
            }
        }

        return ModalPanel.modalPanel;
    }

    public void NewChoice(
        ModalPanelDetails details)
    {
        this.ModalPanelObject.SetActive(true);
        
        this.Button1.gameObject.SetActive(false);
        this.Button2.gameObject.SetActive(false);
        this.Button3.gameObject.SetActive(false);
        
        this.Button1.onClick.RemoveAllListeners();
        this.Button2.onClick.RemoveAllListeners();
        this.Button3.onClick.RemoveAllListeners();
        
        this.Title.text = details.Title;
        this.Message.text = details.Message;

        if (details.Button1Details != null)
        {
            this.Button1Text.text = details.Button1Details.ButtonTitle;

            this.Button1.onClick.AddListener(details.Button1Details.Action);
            this.Button1.onClick.AddListener(this.ClosePanel);

            this.Button1.gameObject.SetActive(true);
        }

        if (details.Button2Details != null)
        {
            this.Button2Text.text = details.Button2Details.ButtonTitle;

            this.Button2.onClick.AddListener(details.Button2Details.Action);
            this.Button2.onClick.AddListener(this.ClosePanel);

            this.Button2.gameObject.SetActive(true);
        }

        if (details.Button3Details != null)
        {
            this.Button3Text.text = details.Button3Details.ButtonTitle;

            this.Button3.onClick.AddListener(details.Button3Details.Action);
            this.Button3.onClick.AddListener(this.ClosePanel);

            this.Button3.gameObject.SetActive(true);
        }
    }

    private void ClosePanel()
    {
        this.ModalPanelObject.SetActive(false);
    }
}
