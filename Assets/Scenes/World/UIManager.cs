using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text EXP;
    [SerializeField] private TMP_Text Level;
    [SerializeField] private GameObject Menu;

    private void Awake()
    {
        Assert.IsNotNull(EXP);
        Assert.IsNotNull(Level);
        Assert.IsNotNull(Menu);
    }

    public void UpdateLevel()
    {
        Level.text = Level.ToString();
    }

    public void UpdateEXP(int CurrentPlayerXP, int RequiredEXP)
    {
        EXP.text = CurrentPlayerXP.ToString() + " / " + RequiredEXP.ToString();
    }

    public void ToggleMenu()
    {
        Menu.SetActive(!Menu.activeSelf);
    }

    
}
