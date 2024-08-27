using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GénérateurDeMot : MonoBehaviour
{
    public static GénérateurDeMot instance;
        /*Tableau de mot a trouver*/
   public  string[] Hololive = new string [] { "okayu", "korone", "miho", "kanatan" ,"cinder", "fubuki" , "subaru" , "sakamatacloe"};
   public  string[] GameCharacter = new string[] { "noire", "yomis" ,"ceris" , "sonic" , "amy" , "asuna", "kirito"};
    /*string[] Anime = new string[] {"" };*/


            // Start is called before the first frame update
    void Awake()
    {
       instance = this;
    }
    // objectif selectionner un mot aléatoir dans un des différent tableau
    public string SelectWord()
    {
       int index = Random.Range(0, Hololive.Length);
        return Hololive[index];
    }
}