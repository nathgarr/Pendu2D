using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.EditorTools;
using UnityEngine.Events;
using Unity.VisualScripting;
using TMPro.EditorUtilities;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Game game;
    int score = 0;
    public UnityEvent OnWrongLetter;
    /*string wordToDisplay = " ";*/
    [SerializeField] TextMeshProUGUI letter_played;
    [SerializeField] TextMeshProUGUI word_To_Find;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        StartNewGame();
        //faire aparaitre le mot aleatoire selectionner dissimuler par _
        string wordSecret = game.word;
      /*  while (word_To_Find.text.Length()! wordSecret.Length()){
            word_To_Find.text += "_";
        }*/
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
        if (letter != string.Empty || score <= 7)
        {
            score++;
            string wordSecret = game.word;
            // envoyer la lettre dans la liste de lettre jouer sa fonctionne 
            //Hello, déclare un string vide string wordToDisplay = string. empty . Dans une boucle for tu vas regarder pour chacune des lettres si elle a été proposée par le joueur,  si oui tu ajouter la lettre sinon tu ajoutés un . Exemple: wordToDisplay += ""; tu fini par afficher wordToDisplay dans ton champs text

            if (!game.playedLetters.Contains(letter))
            {
                game.playedLetters.Insert(0, letter);
                letter_played.text += game.playedLetters[0] + " ";
            }
            for (int i =0; i != 1;)
            {
                if (wordSecret.Contains(letter))
                {
                    word_To_Find.text += letter;
                }
                i++;
            }
            //verifier si la letre jouer et dans le mot ou non si oui afficher la lettre si non aficher personage
            if (game.word.Contains(letter))
            {
                Debug.Log("wow tu a trouver une lettre");
                SoundController.Instance.OnFindSound();
                

            }
            else
            {
                OnWrongLetter.Invoke();
                Debug.Log("sa fait mal");
                SoundController.Instance.OnFailSound();
            }
        }

        else
        {

        }
    }
}
