using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    private void Start(){
        playMusic("background");
    }
    public void playMusic(string name){
        Sound s = Array.Find(musicSound, x => x.name == name);
        if(s == null){
            Debug.Log("Sound Not Found");

        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void playSFX(string name){
            Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null){
            Debug.Log("Sound Not Found");

        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
        public void stopSFX(string name){
            Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null){
            Debug.Log("Sound Not Found");

        }
        else
        {
            sfxSource.Stop();
        }
    }
    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX() {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume) {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume){
        sfxSource.volume = volume;
    }
}
