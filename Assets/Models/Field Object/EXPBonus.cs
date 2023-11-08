using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnClick : MonoBehaviour
{
    public string sceneNameToLoad; // Name of the scene you want to load

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 ))
        {
            LoadNewScene();
        }
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(sceneNameToLoad); // Load the specified scene
    }
}
