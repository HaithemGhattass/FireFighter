using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T Instance;

    public static T Instance_
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();
            }

            DontDestroyOnLoad(Instance);

            return Instance;
        }
    }
}
