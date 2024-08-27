using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip painSound;
    [SerializeField]
    private AudioClip findingSound;
    // objectif lancer le bruit lorsque on ne trouve pas de lettre si on trouve une lettre lancer l'autre

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public void OnFailSound()
    {
        source.PlayOneShot(painSound);
    }
    public void OnFindSound()
    {
        source.PlayOneShot(findingSound);
    }

}
