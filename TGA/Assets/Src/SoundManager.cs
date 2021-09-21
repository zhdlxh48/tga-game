using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SoundType
{
    Bgm,
    Effect,
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField]
    private AudioSource bgm;

    [SerializeField]
    private AudioSource sfx;

    [SerializeField]
    private SoundAttributeDictionary soundAttribute;

    [SerializeField]
    private AudioClipDictionary audioList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public float GetSoundVolume(SoundType type)
    {
        return soundAttribute[type];
    }

    public void SetSoundVolume(SoundType type, float vol)
    {
        soundAttribute[type] = vol;
    }

    public AudioClip GetAudioClip(string audioName)
    {
        return audioList[audioName];
    }

    public void PlayBgm(string audioName)
    {
        bgm.clip = audioList[audioName];
        bgm.Play();
    }

    public void StopBgm()
    {
        bgm.Stop();
    }

    public void PlaySfx(string audioName)
    {
        sfx.Stop();
        sfx.PlayOneShot(audioList[audioName]);
    }

    public void StopSfx()
    {
        sfx.Stop();
    }

    private void Update()
    {
        bgm.volume = soundAttribute[SoundType.Bgm];
        sfx.volume = soundAttribute[SoundType.Effect];
    }
}
