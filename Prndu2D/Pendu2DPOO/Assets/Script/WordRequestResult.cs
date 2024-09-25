using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordRequestResult 
{
    // stock les donn� nec�ssaire pour piocher un mot via l'api
    public string status = "";
    public string motChoisi = "";
    public int nombreDeMots ;
    public int emplacementDuMotDansLeDictionnaire;
    public string regles = "";
}
