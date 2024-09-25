using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;


public class UserHolder : MonoBehaviour
{
    public static UserHolder Instance;
    [System.NonSerialized]
    public UserProfile currentUser;
    public static bool Exists { get { return Instance != null; } }
    public static bool userLoaded
    {
        get
        { 
            if (Instance == null)  return false;
            return Instance.currentUser != null;
        }
    }
    private void Awake()
    {
        // ne pas detrurie le profile au chargement d'autre scene
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public UserProfile CreateUser(string userName)
    {
        //  sauvegarde du profil
        UserProfile profile = new UserProfile(userName);
        SaveUserOnDisk(profile);
        return profile;

    }
    public void SetActiveUser(UserProfile user)
    {
        // activer le profile
        currentUser = user;
    }
    public void SaveUserOnDisk(UserProfile user)
    {
        //converti les donenr du joueur en Json
        string userData = JsonUtility.ToJson(user);
        string path = Application.dataPath + "/Users/" + user.name + ".txt";
        File.WriteAllText(path, userData);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
    public List<string> GetAllUsers()
    {
        // recupere tou les user stocker  et genere les dans le menu load pour nous laisser choisir
        string path = Application.dataPath + "/Users";
        var filePathArray = Directory.GetFiles(path, "*.txt");

        List<string> users = new List<string>();

        foreach (var filePath in filePathArray)
        {
            StreamReader _streamReader = File.OpenText(filePath);
            string profileData = _streamReader.ReadToEnd();
            users.Add(profileData);
        }
        return users;
    }
}
