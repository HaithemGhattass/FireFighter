using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidsSceneManager
{
    public override void DroidTapped(GameObject Droid)
    {
        SceneManager.LoadScene(PocketDroidsConstants.SCENE_CAPTURE, LoadSceneMode.Additive);
    }

    public override void PlayerTapped(GameObject Player)
    {
        
    }
}
