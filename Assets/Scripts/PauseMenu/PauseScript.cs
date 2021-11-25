using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    EventInstance SFXVolumeTestEvent;
    Bus Music;
    Bus SFX;
    Bus Master;
    float MusicVolume;
    float SFXVolume ;
    float MasterVolume;
    bool started = true;
    public Slider musicSlider, SFXSlider, MasterSlider;

    private void Awake()
    {
        Music = RuntimeManager.GetBus("bus:/Master/Music");
        SFX= RuntimeManager.GetBus("bus:/Master/SFX");
        Master = RuntimeManager.GetBus("bus:/Master");
        SFXVolumeTestEvent = RuntimeManager.CreateInstance("event:/PLAYER/SHOOT");
        Music.getVolume(out float musicValue);
        musicSlider.value = musicValue;
        SFX.getVolume(out float SFXValue);
        SFXSlider.value = SFXValue;
        Master.getVolume(out float MasterValue);
        MasterSlider.value = MasterValue;
        started = true;

    }

    private void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        Master.setVolume(MasterVolume);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }
    public void MusicVolumeLevel(float newVolumeLevel)
    {
        MusicVolume = newVolumeLevel;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
        if (!started)
        {
            PLAYBACK_STATE Pbstate;
            SFXVolumeTestEvent.getPlaybackState(out Pbstate);
            if (Pbstate != PLAYBACK_STATE.PLAYING)
            {
                SFXVolumeTestEvent.start();
            }
        }
        else
        {
            started = false;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }
}
