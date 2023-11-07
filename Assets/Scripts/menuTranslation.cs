using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;
using UnityEngine.SceneManagement;

public class ImageScrollController : MonoBehaviour
{
    public RectTransform imageTransform; // Reference to the RectTransform of your image
    private Vector3 initialPosition;     // The initial position of the image
    private Vector3 startPosition;        // The starting position of the animation
    private Vector3 endPosition;          // The ending position of the animation
    public float scrollDuration = 2f;    // Duration of the scrolling animation in seconds
    public TextMeshProUGUI tapToStartText;
    private float startTime;
    private bool isAnimating = false;
    private bool isGlimpsing = false; // Track if the text is currently glimpsing
    private bool gameStarted = false; // Track if the game has started
    public GameObject dialogpannel;
        public GameObject firefighter;

    private bool glimpse = true;

    private IEnumerator GlimpseText()
    {
        while (glimpse) // Continuous glimpse effect
        {
            // Hide the text
            tapToStartText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f); // Hide for 0.5 seconds

            // Show the text
            tapToStartText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f); // Show for 0.5 seconds
        }
    }
    private void Start()
    {
        // Store the initial position of the image
        tapToStartText.gameObject.SetActive(false);
        initialPosition = imageTransform.localPosition;
        StartScrollAnimation();
    }

  private void Update()
{
    if (isAnimating)
    {
        // Calculate the time elapsed since the animation started
        float elapsedTime = Time.time - startTime;

        // Calculate the normalized progress (0 to 1) of the animation
        float t = Mathf.Clamp01(elapsedTime / scrollDuration);

        // Interpolate the position between the start and end positions
        imageTransform.localPosition = Vector3.Lerp(startPosition, endPosition, t);

        // Check if the animation has finished
        if (t >= 1.0f)
        {
            // Animation is complete
            isAnimating = false;
        }
    }
    else
    {
        if (!gameStarted)
        {
            if (Input.touchCount > 0)
            {
                // Stop the glimpse effect and hide the text
                StopCoroutine(GlimpseText());
                isGlimpsing = false;
                    glimpse = false;
                tapToStartText.gameObject.SetActive(false);
                    firefighter.SetActive(false);
                // Start the game
                dialogpannel.SetActive(true);
                gameStarted = true; // Ensure we only start the game once
            }
            else if (!isGlimpsing)
            {
                // Animation has ended, show the "Tap to Start" label
                tapToStartText.gameObject.SetActive(true);
                tapToStartText.text = "Tap to Start";

                // Start the glimpse effect
                StartCoroutine(GlimpseText());
                isGlimpsing = true;
            }
        }
    }
}

    public void StartScrollAnimation()
    {
        dialogpannel.SetActive(false);
        // Calculate the start and end positions based on the initial position
        startPosition = initialPosition + new UnityEngine.Vector3(0, 900, 0);
        endPosition = initialPosition + new UnityEngine.Vector3(0, -300, 0);

        // Start the scrolling animation
        startTime = Time.time;
        isAnimating = true;
    }
}
