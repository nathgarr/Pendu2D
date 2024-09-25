using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISoundControler : MonoBehaviour
{
    [SerializeField]
    private AudioClip MusicToPlay;

    private void Awake()
    {
        AddOnClickEvent();
    }

    
    void AddOnClickEvent()
    {
        //si tu click sur un button alor envoyer le son 
        Button button = GetComponent<Button>();
        button.onClick.AddListener(UiMusic);
    }
    void UiMusic()
    {
        // jouer le son
       AudioManager.PlaySFX(MusicToPlay);
    }
}
