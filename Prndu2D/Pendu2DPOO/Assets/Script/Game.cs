using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class Game
{
    //mot tirer au hazard
    public string word;
    //list de lettre jouer
    public List<string> playedLetters;
    public int maxLife =7;

    // fonction qui permet de setup les pv du joueur 
    public int Life {
        get {
            int result=maxLife-WrongLetter;
            if(result < 0 )result = 0;
            return result;
        }
    }
    //fonction qui verifie que la lettre entrer et bien dans le mot sinon rien
    public int WrongLetter
    {
        get
        {
            int result = 0;
            foreach (string letter in playedLetters)
            {
                if (word.Contains(letter)) continue;
                result++;
            }
            return result;
        }
    }
    //createur d'objet
    public Game(string word)
    {
        this.word = word;
        playedLetters = new List<string>();
    }
    public void AddPlayedLetter(string letter)
    {
        if (playedLetters.Contains(letter))return;
        playedLetters.Add(letter);
    }
}
