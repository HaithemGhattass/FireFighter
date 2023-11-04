

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public ARRaycastManager raycastManager;
    public Vector3 spawnArea;
    public float spawnInterval = 5.0f;
    private int total = 0; 

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon) && total < 3)
            {
                Pose hitPose = hits[0].pose;
                Vector3 randomOffset = new Vector3(
                    Random.Range(-spawnArea.x, spawnArea.x),
                    0.0f,  // Adjust the height as needed
                    Random.Range(-spawnArea.z, spawnArea.z)
                );

                Vector3 spawnPosition = hitPose.position + randomOffset;
                total += 1; 
                Instantiate(arObjectToSpawn, spawnPosition, Quaternion.identity);

            }
        }
    }
}

/*
public class ARPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private GameObject spawnedObject;
    private bool placementPosIsValid = false;
    private float time = 0.0f;
    public float interpolationPeriod = 60f;
    private int num = 0;
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
     //   if( spawnedObject == null && placementPosIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
      //  {
       //     ARplaceObject();
       // }
      
       

        time += Time.deltaTime;
        
        if (time >= interpolationPeriod && num < 5)
        {
            time = time - interpolationPeriod;

            ARplaceObject();
            num += 1;

            //UpdatePlacementIndicator();
            // execute block of code here
        }
        UpdatePlacementPos();



    }
    void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPosIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);

        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    void UpdatePlacementPos()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPosIsValid = hits.Count > 0;
        if (placementPosIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }
    void ARplaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, new Vector3(PlacementPose.position.x , PlacementPose.position.y, PlacementPose.position.z), PlacementPose.rotation);
    }
} */

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private GameObject spawnedObject;
    private bool placementPosIsValid = false;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if( spawnedObject == null && placementPosIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARplaceObject();
        }
        UpdatePlacementPos();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPosIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);

        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    void UpdatePlacementPos()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPosIsValid = hits.Count > 0;
        if (placementPosIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }
    void ARplaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }
}

 */