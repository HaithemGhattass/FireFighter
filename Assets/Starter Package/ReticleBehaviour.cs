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
using System.Linq;

using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleBehaviour : MonoBehaviour
{
    public GameObject Child;
    public DrivingSurfaceManager DrivingSurfaceManager;

    public ARPlane CurrentPlane;

    // Start is called before the first frame update
    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        /* Determine the centre of the screen*/
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        /* Conduct a raycast*/
        var hits = new List<ARRaycastHit>();
        DrivingSurfaceManager.RaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);

        /* Determine the intersection point of interest*/
        CurrentPlane = null;
        ARRaycastHit? hit = null;
        if (hits.Count > 0)
        {
            /* If you do not have a locked plane already.*/
            var lockedPlane = DrivingSurfaceManager.LockedPlane;
            hit = lockedPlane == null
            /* Use the first hit in `hits`.*/
            ? hits[0]
            /* Else, use the locked plane if it's there.*/
            : hits.SingleOrDefault(x => x.trackableId == lockedPlane.trackableId);
        }

        /* If the hit has a value. Move GameObject to the location of the hit.*/
        if (hit.HasValue)
        {
            CurrentPlane = DrivingSurfaceManager.PlaneManager.GetPlane(hit.Value.trackableId);
            transform.position = hit.Value.pose.position;
        }
        Child.SetActive(CurrentPlane != null);
    }
}
