

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject[] arObjectToSpawn;
    public GameObject SettingsToSpawn;
    public ARRaycastManager raycastManager;
    public UnityEngine.Vector3 spawnArea;
    public float spawnInterval = 5.0f;
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    private bool spawningextinguisher = true;
    private bool spawningpoly = true;
    private bool spawningfire = true;


    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            UnityEngine.Vector2 screenCenter = new UnityEngine.Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
            {
                if (scoreManager.GetScore() == 0 && spawningextinguisher == true)
                {
                    Pose hitPose = hits[0].pose;


                    UnityEngine.Vector3 spawnPosition = hitPose.position;

                    Instantiate(arObjectToSpawn[0], spawnPosition, UnityEngine.Quaternion.identity);
                    spawningextinguisher = false;

                }
                if (scoreManager.GetScore() == 1 && spawningpoly == true)
                {
                    Pose hitPose = hits[0].pose;


                    UnityEngine.Vector3 spawnPosition = hitPose.position;
                    Instantiate(arObjectToSpawn[1], spawnPosition, UnityEngine.Quaternion.identity);
                    spawningpoly = false;
                    if(spawningfire == true){
                     Instantiate(arObjectToSpawn[2], spawnPosition, UnityEngine.Quaternion.identity);
                    spawningfire = false;

                    }
                }
           
                


            }

        }
    }
    public void SpawnSettings()
    {
        UnityEngine.Vector2 screenCenter = new UnityEngine.Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {

            Pose hitPose = hits[0].pose;

            UnityEngine.Vector3 spawnPosition = hitPose.position;

            Instantiate(SettingsToSpawn, spawnPosition, UnityEngine.Quaternion.identity);





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
        var screenCenter = Camera.current.ViewportToScreenPoint(new UnityEngine.Vector3(0.5f, 0.5f));
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
        spawnedObject = Instantiate(arObjectToSpawn, new UnityEngine.Vector3(PlacementPose.position.x , PlacementPose.position.y, PlacementPose.position.z), PlacementPose.rotation);
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
        var screenCenter = Camera.current.ViewportToScreenPoint(new UnityEngine.Vector3(0.5f, 0.5f));
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