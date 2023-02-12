using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables
    public static AudioManager instance;

    public AudioSource musicsSource { get { return _musicsSource; } private set { } }
    [SerializeField] private AudioSource _musicsSource;

    public AudioSource soundsSource { get { return _soundsSource; } private set { } }
    [SerializeField] private AudioSource _soundsSource;
    #endregion


    #region Update
    private void Awake()
    {
        if (instance != null) // Singleton instanciation 
        {
            Debug.Log($"Plus d'une instance de {this} dans la scène !" );
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion



    #region Methods
    public void PlayMusic(AudioClip audioClip)
    {
        musicsSource.clip = audioClip;
    }

    public void PlaySound(AudioClip audioClip)
    {
        soundsSource.PlayOneShot(audioClip);
    }
    #endregion
}
