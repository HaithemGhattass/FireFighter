using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Camera arCamera;
    public GameObject objectToPickUp;
    public TextMeshProUGUI tapToStartText;
    public Transform targetTransform;
    private void Start()
    {
        arCamera = Camera.main; // Make sure your AR camera is tagged as "MainCamera."
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider != null)
                    {
                        tapToStartText.SetText("Hit object: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.name == objectToPickUp.name + "(Clone)")
                        {
                            tapToStartText.SetText("Picked up object: "+  objectToPickUp.name);
                            // Perform pickup logic here.
                            // You may want to deactivate or destroy the object.
                          //  Destroy(hit.collider.gameObject);

                            Vector3 targetPosition = targetTransform.position;
                            float moveSpeed = 2.0f; // Adjust the speed as needed.
                            StartCoroutine(MoveObjectSmoothly(hit.collider.gameObject.transform, targetPosition, moveSpeed));

                            StartCoroutine(DisappearObject(hit.collider.gameObject));

                            // Increase the player's score.
                            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Get the ScoreManager reference.
                            if (scoreManager != null)
                            {
                                scoreManager.AddToScore(1); // Adjust the pointsToAdd as needed.
                            }

                        }

                    }
                }
            }
        }
    }
    private IEnumerator MoveObjectSmoothly(Transform objTransform, Vector3 targetPosition, float speed)
    {
        float journeyLength = Vector3.Distance(objTransform.position, targetPosition);
        float startTime = Time.time;

        while (objTransform.position != targetPosition)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            objTransform.position = Vector3.Lerp(objTransform.position, targetPosition, fractionOfJourney);
            yield return null;
        }
    }
    private IEnumerator DisappearObject(GameObject obj)
    {
        // You can gradually reduce the object's scale to make it appear as if it's disappearing.
        while (obj.transform.localScale.magnitude > 0.01f)
        {
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, Vector3.zero, 0.1f);
            yield return null;
        }

        // Optionally, destroy the object after a delay.
        Destroy(obj);
    }


}
