using UnityEngine;
using UnityEngine.SceneManagement;

public class RenderPrefabs : MonoBehaviour
{
    public GameObject prefab; // Reference to the prefab you want to instantiate
    public int numberOfPrefabs = 5; // Number of prefabs to instantiate
    public float range = 10f; // Range within which the prefabs will be instantiated
    public string sceneToLoad = "Game"; // Name of the scene to load upon collision

    void Start()
    {
        Render();
    }
    void Update() {

         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("FireMap"))
                {
                    SceneManager.LoadScene(sceneToLoad); // Load the specified scene
                }
            }
        }
    }

    void Render()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range));
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }


}
