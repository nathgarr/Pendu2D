using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        // si une valeur personaliser via le slider exist alor la charger sinon remetre le volume d'origine
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusic();
        }
    }
    public void SetMusic()
    {
        // fonction qui a pour but de parametrer mon slider pour controler le volume de la music
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    private void LoadVolume()
    {
        // sauvegarder le volume customizer lord d'une parti
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusic();
    }
}
