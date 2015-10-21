using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour
{
    public Text DisplayText;
    public float DisplayTime;
    public float FadeTime;

    private static DisplayManager displayManager;

    private IEnumerator fadeAlpha;

    public static DisplayManager Instance()
    {
        if (!DisplayManager.displayManager)
        {
            DisplayManager.displayManager = Object.FindObjectOfType<DisplayManager>();

            if (!DisplayManager.displayManager)
            {
                Debug.LogError("There needs to be one active DisplayManager script on a GameObject in your scene.");
            }
        }

        return DisplayManager.displayManager;
    }

    public void DisplayMessage(string message)
    {
        this.DisplayText.text = message;
        this.SetAlpha();
    }

    private void SetAlpha()
    {
        if (this.fadeAlpha != null)
        {
            this.StopCoroutine(this.fadeAlpha);
        }

        this.fadeAlpha = this.FadeAlpha();
        this.StartCoroutine(this.fadeAlpha);
    }

    private IEnumerator FadeAlpha()
    {
        Color resetColor = this.DisplayText.color;
        resetColor.a = 1;

        this.DisplayText.color = resetColor;

        yield return new WaitForSeconds(this.DisplayTime);

        while (this.DisplayText.color.a > 0)
        {
            Color displayColor = this.DisplayText.color;
            displayColor.a -= Time.deltaTime / this.FadeTime;

            this.DisplayText.color = displayColor;

            yield return null;
        }

        yield return null;
    }
}