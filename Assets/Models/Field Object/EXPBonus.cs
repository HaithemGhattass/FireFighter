using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXPBonus : MonoBehaviour
{
    public string sceneNameToLoad; // Name of the scene you want to load
    

    private void OnMouseDown()
    {
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(sceneNameToLoad); // Load the specified scene
    }
}
