﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle fullscreen;
    public EventSystem eventSystem;
    public Button newGame;
    public Button backToMainMenu;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectSlider;
    public Slider brightnessSlider;
    public float outMasterVolume;
    public float outMusicVolume;
    public float outEffectVolume;
    public ParticleSystem pS1;
    public ParticleSystem pS2;

    [SerializeField] Image brightness;

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", AudioManager.Instance.VolumeTodB(volume));
    }
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", AudioManager.Instance.VolumeTodB(volume));
    }
    public void setEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", AudioManager.Instance.VolumeTodB(volume));
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if(!isFullscreen)
        {
            Screen.SetResolution(1280, 720, false);
        }
    }

    public void BackToMainMenu()
    {
        eventSystem.SetSelectedGameObject(newGame.gameObject);
    }

    public void Brightness(float alpha)
    {
        NewBrightness.Instance.brightnessValue = alpha * -1f;
    }

    public void Awake()
    {

        ParticleSystem.EmissionModule module1 = pS1.emission;
        ParticleSystem.EmissionModule module2 = pS2.emission;
        module1.enabled = true;
        module2.enabled = true;

      
        //GetComponent<ParticleSystem>().Play();
        pS1.Play();
        pS2.Play();

    }

    private void Start()
    {
        fullscreen.isOn = Screen.fullScreen;
        if (AudioManager.instance.isNewGameVolume)
        {
            audioMixer.SetFloat("MasterVolume", -5f);
            audioMixer.GetFloat("MasterVolume", out outMasterVolume);
            masterSlider.value = AudioManager.Instance.dBToVolume(outMasterVolume);

            audioMixer.SetFloat("MusicVolume", -5f);
            audioMixer.GetFloat("MusicVolume", out outMusicVolume);
            musicSlider.value = AudioManager.Instance.dBToVolume(outMusicVolume);

            audioMixer.SetFloat("EffectVolume", -5f);
            audioMixer.GetFloat("EffectVolume", out outEffectVolume);
            effectSlider.value = AudioManager.Instance.dBToVolume(outEffectVolume);

            AudioManager.instance.isNewGameVolume = false;
        }
    }

    private void Update()
    {
        if(backToMainMenu.gameObject.activeInHierarchy)
        {
            eventSystem.SetSelectedGameObject(backToMainMenu.gameObject);
        }
        audioMixer.GetFloat("MasterVolume", out outMasterVolume);
        masterSlider.value = AudioManager.Instance.dBToVolume(outMasterVolume);
        audioMixer.GetFloat("MusicVolume", out outMusicVolume);
        musicSlider.value = AudioManager.Instance.dBToVolume(outMusicVolume);
        audioMixer.GetFloat("EffectVolume", out outEffectVolume);
        effectSlider.value = AudioManager.Instance.dBToVolume(outEffectVolume); audioMixer.GetFloat("MasterVolume", out outMasterVolume);
        brightnessSlider.value = NewBrightness.instance.brightnessValue * -1f;
    }

}
