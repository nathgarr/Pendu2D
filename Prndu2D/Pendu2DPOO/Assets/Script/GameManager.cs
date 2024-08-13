using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.EditorTools;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Game game;
    int score = 0;
    public UnityEvent OnWrongLetter;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        StartNewGame();
    }
    void StartNewGame()
    {
        //recherche dans le tableau hololive pour stocker l'une des valeur du tableau
        string word = GénérateurDeMot.instance.SelectWord();
        game = new Game(word);
    }
    public void OnLetterPlayed(string letter)
    {

        //recupération des lettre ecrite par le joueur dans la console
        /* Debug.Log(letter);*/

        letter = letter.ToLower();

        //verifi si sai un string et non un espace vide 
        if (letter != string.Empty)
        {

            // envoyer la lettre dans la liste de lettre jouer sa fonctionne ai envoi des espace vide
            
            if(!game.playedLetters.Contains(letter))
            {
                game.playedLetters.Insert(0, letter);
            }


            //verifier si la letre jouer et dans le mot ou non si oui afficher la lettre si non aficher personage
            if (game.word.Contains(letter))
            {
                Debug.Log("wow tu a trouver une lettre");
            }
            else
            {
                OnWrongLetter.Invoke();
                Debug.Log("sa fait mal");
            }
        }

        else
        {

        }
    }
}
