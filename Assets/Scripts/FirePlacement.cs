using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FirePlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    //public GameObject shoot;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;


    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
      //  shoot.SetActive(false);
    }

    void Update()
    {
        // Automatically spawn the object when a valid placement pose is found
        if (spawnedObject == null && placementPoseIsValid)
        {
            ARPlaceObject();
          //  shoot.SetActive(true);
           
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, new Vector3(PlacementPose.position.x,PlacementPose.position.y,PlacementPose.position.z + 1), PlacementPose.rotation);
    }
}
