/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FireSpawner : MonoBehaviour
{
    public DrivingSurfaceManager DrivingSurfaceManager;
    public PackageBehaviour Package;
    public GameObject PackagePrefab;
    public float spawnInterval = 4.0f; // Adjust the interval as needed
    private float lastSpawnTime;
    private ARPlane currentPlane;
    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnPackageCoroutine());
    }

    private IEnumerator SpawnPackageCoroutine()
    {
        while (true)
        {
            // Check if it's time to spawn a package
            if (Time.time - lastSpawnTime >= spawnInterval)
            {
                lastSpawnTime = Time.time;

                // Check if there is a locked plane from DrivingSurfaceManager
                var lockedPlane = DrivingSurfaceManager.LockedPlane;

                if (lockedPlane != null)
                {
                    currentPlane = lockedPlane;
                    SpawnPackage(currentPlane);
                }
            }

            yield return null; // Wait for the next frame
        }
    }
    public static Vector3 RandomInTriangle(Vector3 v1, Vector3 v2)
    {
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);
        if (v + u > 1)
        {
            v = 1 - v;
            u = 1 - u;
        }

        return (v1 * u) + (v2 * v);
    }

    public static Vector3 FindRandomLocation(ARPlane plane)
    {
        // Select random triangle in Mesh
        var mesh = plane.GetComponent<ARPlaneMeshVisualizer>().mesh;
        var triangles = mesh.triangles;
        var triangle = triangles[(int)Random.Range(0, triangles.Length - 1)] / 3 * 3;
        var vertices = mesh.vertices;
        var randomInTriangle = RandomInTriangle(vertices[triangle], vertices[triangle + 1]);
        var randomPoint = plane.transform.TransformPoint(randomInTriangle);

        return randomPoint;
    }



    public void SpawnPackage(ARPlane plane)
    {
        var packageClone = GameObject.Instantiate(PackagePrefab);
        packageClone.transform.position = FindRandomLocation(plane);



        currentPlane = plane;
    }

    private void Update()
    {
        if (currentPlane != null)
        {
            var packagePosition = currentPlane.center;
            packagePosition.y = currentPlane.transform.position.y; // Match the plane's height
            PackagePrefab.transform.position = packagePosition;
        }
    }
}
