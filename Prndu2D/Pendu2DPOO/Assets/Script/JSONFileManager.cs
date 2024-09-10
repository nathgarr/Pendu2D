using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.MemoryProfiler;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Networking;

public class JSONFileManager : MonoBehaviour
{
    string fileName = "Data.json";
    string path;
    string url = "https://makeyourgame.fun/api/pendu/avoir-un-mot";
    [System.NonSerialized]
    public WordRequestResult wordRequestResult;

    void Start()
    {
        // modification du pathway du document cela peut etre utile pour le proteger des hacker et empecher les joueur de modifier leur donner
        path = Application.persistentDataPath + "/" + fileName;
    }

    // Update is called once per frame
    /* void Update()
     {
         // si jappui sur la touche du clavier S sa active la sauvegarde
         if (Input.GetKeyDown(KeyCode.S))
         {
             *//*savedData();*//*
             StartCoroutine(GetWordCorout());
         }
         // Si jappui sur la touche R acyive la fonction read 
         if (Input.GetKeyDown(KeyCode.R))
         {
             readData();
         }
     }*/
    public Coroutine GetWord()
    {
        return StartCoroutine(GetWordCorout());
    }
    IEnumerator GetWordCorout()
    {
        using (UnityWebRequest WebRequest = UnityWebRequest.Get(url))
        {
            yield return WebRequest.SendWebRequest();

            switch (WebRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    wordRequestResult = JsonUtility.FromJson<WordRequestResult>(WebRequest.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError("ConnectionError");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Something went wrong {WebRequest.error}");
                    break;
            }
        }
    }

    void savedData()
    {
        // ajout de la class game data
        JSONWrapper wrapper = new JSONWrapper();
        /*    wrapper.gameData = wordRequest;*/
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
                /*wordRequest = wrapper.gameData;*/
                /*Debug.Log(gameData.WordChoose + gameData.Status + gameData.Rules + gameData.WordIndex);*/
            }
            else
            {
                // reset les valeur contenue dans gamedata si le fichier json nexiste plus 
                Debug.Log("Data doesnt exist unable to read the data");
                /*wordRequest = new WordRequestResult();*/
            }
        }
        //si quelque chose et arriver au document json prévenir le joueur
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
