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
        // jouer ce sont si la fonction et appeller 
        source.PlayOneShot(painSound);
    }
    public void OnFindSound()
    {
        // jouer ce sont si la fonction et appeller 
        source.PlayOneShot(findingSound);
    }

}
