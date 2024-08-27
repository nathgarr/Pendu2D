using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class IHMController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI word_To_Find;

    [SerializeField] TextMeshProUGUI letter_played;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onLetterPlayedDel += UpdateWord;
        GameManager.instance.onLetterPlayedDel += UpdatePlayedLetter;
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
            //
            word += currentGame.playedLetters.Contains(letterTmp) ? letterTmp : " _";
        }
        word_To_Find.text = word;
    }
    public void UpdatePlayedLetter(Game game)
    {
        string word = string.Empty;
        foreach (string letter in game.playedLetters)
        {
            word += letter + " ";
        }
        letter_played.text = word;

    }
}
