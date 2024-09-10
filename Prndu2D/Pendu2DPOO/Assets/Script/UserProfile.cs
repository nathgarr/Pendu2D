using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProfile
{
    public string name;
    public int bestScore, currentScore;
    public List<string> wordPlayed;

    public UserProfile(string name)
    {
        this.name = name;
        bestScore = 0;
        currentScore = 0;
        wordPlayed = new List<string>();
    }
}
