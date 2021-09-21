using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void OnLoadSfx(string audioName)
    {
        SoundManager.instance.PlaySfx(audioName);
    }

    public void OnLoadBgm(string audioName)
    {
        SoundManager.instance.PlayBgm(audioName);
    }
}
