using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class JSONFile : MonoBehaviour
{
    string fileName = "Data.json";
    string path;

    GameData gameData = new GameData();

    void Start()
    {
        // modification du pathway du document cela peut etre utile pour le proteger des hacker et empecher les joueur de modifier leur donner
        path = Application.persistentDataPath + "/" + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        // si jappui sur la touche du clavier S sa active la sauvegarde
        if (Input.GetKeyDown(KeyCode.S))
        {
            savedData();
        }
        // Si jappui sur la touche R acyive la fonction read 
        if (Input.GetKeyDown(KeyCode.R))
        {
            readData();
        }
    }

    void savedData()
    {
        // ajout de la class game data
        JSONWrapper wrapper = new JSONWrapper();
        wrapper.gameData = gameData;
        // fonction qui a pour but de sauvegarder des valeur dans Game Data et générer un document Json pour stocker la save
        string content = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, content);
    }

    void readData()
    {
        try 
        { 
            if (System.IO.File.Exists(path))
            {
                // si le document de sauvegard.Json exist alor tu peux lire les valeur 
                string contents = System.IO.File.ReadAllText(path);
                JSONWrapper wrapper = JsonUtility.FromJson<JSONWrapper>(contents);
                gameData = wrapper.gameData;
                Debug.Log(gameData.WordChoose + gameData.Status + gameData.Rules + gameData.WordIndex);
            }
            else 
            {
                // reset les valeur contenue dans gamedata si le fichier json nexiste plus 
                Debug.Log("Data doesnt exist unable to read the data");
                gameData = new GameData();
            }
        }
        //si quelque chose et arriver au document json prévenir le joueur
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
