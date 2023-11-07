using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeTextOnClick : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Reference to the Text element.
    public TextMeshProUGUI dialogButton; // Reference to the Button element.

    private string[] dialogTexts = { "You will be equipped with state-of-the-art AR tools to navigate our urban landscape, locate fires, and combat the flames. Your training and bravery will be your best allies.", "Your actions will determine the safety of our city. Get ready to extinguish the fires, save trapped civilians, and lead them to safety. Show your skills, be a hero, and become the ultimate AR firefighter" }; // Array of dialog texts.
    private string[] buttonTexts = {  "Next", "Start" }; // Array of button texts.
    private int currentDialog = 0; // To track the current dialog.

    public void ShowNextDialog()
    {
        if (currentDialog < dialogTexts.Length)
        {
            dialogText.text = dialogTexts[currentDialog]; // Update the dialog text.
            dialogButton.text = buttonTexts[currentDialog]; // Update the button text.
            currentDialog++;
        }
        else
        {
            SceneManager.LoadScene("Game"); // Load the "Game" scene when all dialogs are displayed.
        }
    }
}
