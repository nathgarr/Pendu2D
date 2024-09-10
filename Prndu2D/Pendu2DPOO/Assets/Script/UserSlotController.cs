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
        this.profile = JsonUtility.FromJson<UserProfile>(profileStr);
        userName.text = profile.name;
    }
    public void LoadGame()
    {
        UserHolder.Instance.SetActiveUser(profile);
        MainMenusControler.Instance.LoadGame();
    }
}
