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
    public static bool Exists {  get { return Instance != null; } }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public UserProfile CreateUser(string userName)
    {
        UserProfile profile= new UserProfile(userName);
        SaveUserOnDisk(profile);
        return profile;

    }
    public void SetActiveUser(UserProfile user)
    {
        currentUser = user;
    }
    public void SaveUserOnDisk(UserProfile user)
    {
        string userData = JsonUtility.ToJson(user);
        string path = Application.dataPath + "/Users/" + user.name + ".txt" ;
        File.WriteAllText(path, userData);

#if UNITY_EDITOR
       UnityEditor.AssetDatabase.Refresh();
#endif
    }
    public List<string> GetAllUsers()
    {
        string path = Application.dataPath + "/Users" ;
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
