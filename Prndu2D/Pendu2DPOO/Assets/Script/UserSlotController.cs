using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserSlotController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI userName;
    public UserProfile profile;

   public void SetUser(string profileStr)
    {
        //lire le profile json 
        this.profile = JsonUtility.FromJson<UserProfile>(profileStr);
        userName.text = profile.name;
    }
    public void LoadGame()
    {
        // activé le profile et lancer le jeux
        UserHolder.Instance.SetActiveUser(profile);
        MainMenusControler.Instance.LoadGame();
    }
}
