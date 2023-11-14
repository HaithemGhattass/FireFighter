using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panelToToggle; // Reference to the panel you want to show/hide
    private bool isPanelVisible = false;


    public Slider _musicSlider, _sfxSlider;
      public void Start(){
        panelToToggle.SetActive(isPanelVisible);
    }
    public void ToggleMusic(){
        AudioManager.Instance.ToggleMusic();
    }
     public void ToggleSFX(){
        AudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume(){
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
       public void SFXVolume(){
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
    public void ToggleVisibility()
    {
        isPanelVisible = !isPanelVisible;
        panelToToggle.SetActive(isPanelVisible);
    }
    public void ResetScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene to reset it
        SceneManager.LoadScene(currentSceneIndex);
    }
}
