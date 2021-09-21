using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
    [SerializeField]
    private Slider soundSlider;

    public SoundType controlType;

    private float saveVol;

    private void Awake()
    {
        if (!soundSlider)
        {
            soundSlider = GetComponent<Slider>();
        }

        SoundManager manager = SoundManager.instance;
        if (manager)
        {
            soundSlider.value = manager.GetSoundVolume(controlType);
        }
    }

    private void OnEnable()
    {
        saveVol = soundSlider.value;
    }

    private void Update()
    {
        SoundManager manager = SoundManager.instance;
        if (manager)
        {
            manager.SetSoundVolume(controlType, soundSlider.value);
        }
    }

    public void FixSoundVolume()
    {
        soundSlider.value = saveVol;
        SoundManager manager = SoundManager.instance;
        if (manager)
        {
            manager.SetSoundVolume(controlType, saveVol);
        }
    }
}
