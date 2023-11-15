using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int EXP = 0;
    [SerializeField] private int RequiredEXP = 100;
    [SerializeField] private int LevelBase = 100;
    [SerializeField] private List<GameObject> Droids = new List<GameObject>();

    private int Level = 1;

    public int EXP_
    {
        get { return EXP; }
    }

    public int RequiredEXP_
    {
        get { return RequiredEXP; }
    }

    public int LevelBase_
    {
        get { return LevelBase; }
    }

    public List<GameObject> Droids_
    {
        get { return Droids; }
    }

    public int Level_
    {
        get { return Level; }
    }

    private void Start()
    {
        InitLevelData();   
    }

    public void AddEXP(int EXPToAdd)
    {
        EXP += Mathf.Max(0, EXPToAdd);
    }

    public void AddDroid(GameObject Droid)
    {
        Droids.Add(Droid);
    }

    public void InitLevelData()
    {
        Level = (EXP / LevelBase) + 1;
        RequiredEXP = LevelBase * Level;
    }
}
