using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player CurrentPlayer;

    public Player CurrentPlayer_
    {
        get { return CurrentPlayer; }
    }

    private void Awake()
    {
        Assert.IsNotNull(CurrentPlayer);
    }


}
