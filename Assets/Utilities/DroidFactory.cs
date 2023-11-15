using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DroidFactory : Singleton<DroidFactory>
{
    [SerializeField] private Droid[] AvailableDroids;
    [SerializeField] private Player Player;
    [SerializeField] private float WaitTime = 180.0f;
    [SerializeField] private int StartingDroids = 5;
    [SerializeField] private float MinRange = 5.0f;
    [SerializeField] private float MaxRange = 50.0f;

    private List<Droid> LiveDroids = new List<Droid>();
    private Droid SelectedDroid;

    public List<Droid> LiveDroids_
    {
        get { return LiveDroids;  }
    }

    public Droid SelectedDroid_
    {
        get { return SelectedDroid; }
    }


    private void Awake()
    {
        Assert.IsNotNull(AvailableDroids);
        Assert.IsNotNull(Player);
    }


    void Start()
    {
        for (int i = 0; i < StartingDroids; i++)
        {
            InstantiateDroid();
        }

        StartCoroutine(GenerateDroids());
    }

    private IEnumerator GenerateDroids()
    {
        while (true)
        {
            InstantiateDroid();
            yield return new WaitForSeconds(WaitTime);
        }
    }

    public void DroidWasSelected(Droid droid)
    {
        SelectedDroid = droid;
    }

    private void InstantiateDroid()
    {
        int index = Random.Range(0, AvailableDroids.Length);
        float x = Player.transform.position.x + GenerateRange();
        float y = Player.transform.position.y;
        float z = Player.transform.position.z + GenerateRange();

        LiveDroids.Add(Instantiate(AvailableDroids[index], new Vector3(x, y, z), Quaternion.Euler(index == 0 ? -90 : 0, index == 0 ? 0 : -180, 0)));
    }

    private float GenerateRange()
    {
        float RandomNb = Random.Range(MinRange, MaxRange);
        bool IsPositive = Random.Range(0, 10) < 5;

        return RandomNb * (IsPositive ? 1 : -1);
    }
}
