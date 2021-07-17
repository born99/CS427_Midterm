using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectFloat;
        }
    }
}
