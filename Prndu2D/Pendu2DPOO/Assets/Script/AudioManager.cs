using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource audioSource;   

    private void Awake()
    {
        // si il n'y a pas de référence a cette objet et que la référence et différente de this alor detruie le gameobject
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // le dont destroy on laod permet de conserver l'audio source pour les autre scene 
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void PlaySFX(AudioClip clip)
    {
        // récupéré l'audio source de cette objet
        Instance.audioSource.clip = clip;
        //jouer l'audio source de cette objet
        Instance.audioSource.Play();
    }
}
