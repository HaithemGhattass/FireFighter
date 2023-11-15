using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PocketDroidsSceneManager : MonoBehaviour
{
    public abstract void PlayerTapped(GameObject Player);
    public abstract void DroidTapped(GameObject Droid);
}
