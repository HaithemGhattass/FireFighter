using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
public class WeaponManager : MonoBehaviour
{
    /*
    public GameObject[] extinguisher;
    public XROrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);
            if (collision)
            {
                GameObject _object = Instantiate(extinguisher[Random.Range(0, extinguisher.Length - 1)]);
                _object.transform.position = raycastHits[0].pose.position;
            }
            foreach(var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false); 
            }
            planeManager.enabled = false; 
        }
    } 
    [SerializeField]
    GameObject placementIndicator;
    [SerializeField]
    GameObject extinguisher;
    GameObject spawnerobject;
    ARRaycastManager raycastManager;
    private float spawnInterval = 5.0f; // Adjust this value for the spawn interval
    private float timeSinceLastSpawn = 0.0f;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        placementIndicator.SetActive(false);
      //  touchInput.performed += _ => {PlaceObject(); };
  
    }
    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObjectRandomly();
            timeSinceLastSpawn = 0.0f; // Reset the timer
        }

        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), raycastHits, TrackableType.Planes))
        {
            var hitpos = raycastHits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitpos.position, hitpos.rotation);
            if (!placementIndicator.activeInHierarchy)
                placementIndicator.SetActive(true);
        }
    }
    void SpawnObjectRandomly()
    {
        if (placementIndicator.activeInHierarchy)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
            Vector3 spawnPosition = placementIndicator.transform.position + randomOffset;
            Quaternion spawnRotation = placementIndicator.transform.rotation;
            Instantiate(extinguisher, spawnPosition, spawnRotation);
        }
    }
    */


    public GameObject objectToSpawn;
    public float spawnInterval = 5.0f; // Time between spawns
    public float spawnRadius = 5.0f; // Radius within which the object will spawn

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        // Calculate a random position within the spawn radius
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;

        // Ensure the object is spawned on the ground (adjust the Y position as needed)
        spawnPosition.y = 0.0f;

        // Instantiate the object at the calculated position
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
