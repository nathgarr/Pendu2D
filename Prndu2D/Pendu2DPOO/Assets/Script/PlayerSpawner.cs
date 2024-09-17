using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    public GameObject[] playerPart;
    // Start is called before the first frame update
    
        // ajout d'une fonction dans l'evenement Onwrongletter
        /*GameManager.instance.OnWrongLetter.AddListener(OnFail);*/
    
    // si le joueur ce trompe aficher les morceau du joueur dans la scene
    public void OnFail()
    {
        int index = GameManager.instance.game.maxLife-GameManager.instance.game.Life;
        for (int i = 0; i < index; i++)
        {
            playerPart[i].SetActive(true);
        }
    }
    public void OnReplay()
    {
        for (int i = 0;i < playerPart.Length;i++) 
        {
            playerPart[(int)i].SetActive(false);
        }
    }
}
