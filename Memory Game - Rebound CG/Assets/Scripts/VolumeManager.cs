using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


// A single VolumeManager Scipt that can fit in every slider to controle the volume due to the "enum"
public class VolumeManager : MonoBehaviour
{
    #region Variables
    public enum EVolumeTypes
    {
        Master,
        Music,
        Sound
    }


    public EVolumeTypes volumeType;
    private Slider volumeSlider;
    #endregion


    #region Update
    private void Start()
    {
        volumeSlider = GetComponent<Slider>();

        switch (volumeType)
        {
            case EVolumeTypes.Master:
                volumeSlider.value = AudioListener.volume;
                volumeSlider.onValueChanged.AddListener(newVolume => AudioListener.volume = newVolume);
                break;

            case EVolumeTypes.Music:
                volumeSlider.value = AudioManager.instance.musicsSource.volume;
                volumeSlider.onValueChanged.AddListener(newVolume => AudioManager.instance.musicsSource.volume = newVolume);
                break;

            case EVolumeTypes.Sound:
                volumeSlider.value = AudioManager.instance.soundsSource.volume;
                volumeSlider.onValueChanged.AddListener(newVolume => AudioManager.instance.soundsSource.volume = newVolume);
                break;
        }  
    }
    #endregion
}
