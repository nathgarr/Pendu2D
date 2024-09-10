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
    public UnityEvent OnWrongLetter;
    /*string wordToDisplay = " ";*/
    public delegate void OnLetterPlayedDel(Game CurrentGame);
    public OnLetterPlayedDel onLetterPlayedDel;
    [SerializeField]
    JSONFileManager JSONFileManager;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        // StartNewGameOnline();
        /*StartCoroutine(StartNewGameOnline());*/
        StartNewGameOffline();
    }
    void StartNewGameOffline()
    {
        //recherche dans le tableau hololive pour stocker l'une des valeur du tableau
        string word = GénérateurDeMot.instance.SelectWord();
        game = new Game(word);
    }
    public void loadANewGame()
    {
        string word = GénérateurDeMot.instance.SelectWord();
        game = new Game(word);
        PlayerSpawner.Instance.OnReplay();
        IHMController.Instance.RefreshAll(game);
    }
    IEnumerator StartNewGameOnline()
    {
        yield return JSONFileManager.GetWord();
        game = new Game(JSONFileManager.wordRequestResult.motChoisi);
    }
    public void OnLetterPlayed(string letter)
    {
        // convertir les letre entré de base en majuscule en minuscule afin de comparer avec la liste de mot
        letter = letter.ToLower();

        //verifi si sai un string et non un espace vide 
        if (letter == string.Empty) return;

        bool isMoveCorect = IsMoveCorrect(letter);

        game.AddPlayedLetter(letter);

        // si ismovecorect == true faire quelque chose sinon faire autre chose

        if (isMoveCorect)
        {
            SoundController.Instance.OnFindSound();
        }
        else
        {
            PlayerHpHud.Instance.PlayerErorLeft();
            OnWrongLetter.Invoke();
            SoundController.Instance.OnFailSound();
        }
        // si ce nest pas vide alor faire sa

        if (onLetterPlayedDel != null) onLetterPlayedDel(game);
    }

    // si oui sinon sa sinon encore autre chose 

    bool IsMoveCorrect(string letter)
    {
        if (game.playedLetters.Contains(letter)) return false;
        if (!game.word.Contains(letter)) return false;
        return true;
    }
}
