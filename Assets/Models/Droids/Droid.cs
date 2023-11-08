using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{

    [SerializeField] private float SpawnRate = 0.10f;
    [SerializeField] private float CatchRate = 0.10f;
    [SerializeField] private int ATK = 0;
    [SerializeField] private int DEF = 0;
    [SerializeField] private int HP = 0;

    public float SpawnRate_
    {
        get { return SpawnRate; }
    }

    public float CatchRate_
    {
        get { return CatchRate; }
    }

    public float ATK_
    {
        get { return ATK; }
    }

    public float DEF_
    {
        get { return DEF; }
    }

    public float HP_
    {
        get { return HP; }
    }

   /* private void OnMouseDown()
    {
        PocketDroidsSceneManager[] Managers = FindObjectsOfType<PocketDroidsSceneManager>();
        foreach(PocketDroidsSceneManager SceneManager in Managers)
        {
            if (SceneManager.gameObject.activeSelf)
            {
                SceneManager.DroidTapped(this.gameObject);
            }
        }
    } */

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
