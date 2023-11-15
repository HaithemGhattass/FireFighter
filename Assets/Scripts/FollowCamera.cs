using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    private float distance = 3.0f;
    public GameObject tipPanel;
    public GameObject cross;
       public FireScore fireScore;

    private void Update()
    {
        cross.SetActive(false);
            transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
            transform.rotation = new Quaternion( 0.0f, mainCamera.transform.rotation.y, 0.0f, mainCamera.transform.rotation.w );   
    }
    public void HideThePanel() {
        tipPanel.SetActive(false);
        if(fireScore.getFireScore() > 0) {
        cross.SetActive(true);
        }

    }
}
