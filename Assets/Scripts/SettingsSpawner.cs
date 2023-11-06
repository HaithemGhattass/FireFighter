using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SettingsSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object you want to spawn
    private ARRaycastManager raycastManager;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>(); // Get the ARRaycastManager component
    }

    public void SpawnObject()
    {
        if (objectToSpawn != null && raycastManager != null)
        {
            UnityEngine.Vector3 screenCenter = new UnityEngine.Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            // Raycast from the screen center to detect planes
            if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
            {
                // Get the position of the hit on the detected plane
                Pose hitPose = hits[0].pose;
                UnityEngine.Vector3 spawnPosition = hitPose.position;

                // Spawn the object at the detected position
                Instantiate(objectToSpawn, spawnPosition, UnityEngine.Quaternion.identity);
            }
        }
    }
}
