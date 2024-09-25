using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource audioSource;   

    private void Awake()
    {
        // si il n'y a pas de r�f�rence a cette objet et que la r�f�rence et diff�rente de this alor detruie le gameobject
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
        // r�cup�r� l'audio source de cette objet
        Instance.audioSource.clip = clip;
        //jouer l'audio source de cette objet
        Instance.audioSource.Play();
    }
}
