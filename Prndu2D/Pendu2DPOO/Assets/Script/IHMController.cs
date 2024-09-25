using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class IHMController : MonoBehaviour
{
    public static IHMController Instance;
    [SerializeField]
    public GameObject RestartBtn ;
    [SerializeField] TextMeshProUGUI word_To_Find;

    [SerializeField] TextMeshProUGUI letter_played, score, userName;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameManager.instance.onLetterPlayedDel += UpdateWord;
        GameManager.instance.onLetterPlayedDel += UpdatePlayedLetter;
        UpdateScore();
    }
    public void RefreshAll(Game currentgame)
    {
        // lobjectif et de relancer les fonction pour un reload en douceur des élément
        UpdatePlayedLetter( currentgame);
        UpdateWord(currentgame);
    }
    public void UpdateWord(Game currentGame)
    {
        string word = string.Empty;
        string letterTmp;
        // faire aparaitre les lettre contenu dans le mot pour le moment dans le desordre total
        for (int i = 0; i < currentGame.word.Length; i++)
        {
            letterTmp = currentGame.word[i].ToString();
            /*if (currentGame.playedLetters.Contains(letterTmp))
            {
                word += letterTmp;
            }
            else
            {
                word += " _";
            }*/
            // généré les tiret du mot a trouver
            word += currentGame.playedLetters.Contains(letterTmp) ? letterTmp : " _";
        }
        word_To_Find.text = word;
        if (letter_played != word_To_Find)
        {
            // fai aparaitre le btn restart lorsque q'une lettre et jouer
            RestartBtn.SetActive(true);
        }
    }
    public void UpdatePlayedLetter(Game game)
    {
        string word = string.Empty;
        // pour chaque lettre dans played letter ajouter word a letter avec un espace ce qui va remplir le tableau avec un petit espace
        foreach (string letter in game.playedLetters)
        {
            word += letter + " ";
        }
        letter_played.text = word;

    }
    public void UpdateScore()
    {
        // si le joueur na pas de compte alor ecrire pas d'utilisateur sinon envoyer le score
        if (!UserHolder.Exists ) 
        {
            score.text = "No User";
        }
        else
        {
            score.text = UserHolder.Instance.currentUser.currentScore.ToString();
        }
    }
}
