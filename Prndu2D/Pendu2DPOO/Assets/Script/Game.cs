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
    public int life {
        get {
            int result=maxLife-wrongLetter;
            if(result < 0 )result = 0;
            return result;
        }
    }
    public int wrongLetter
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
}
