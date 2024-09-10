using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileCreationMenu : MonoBehaviour
{
    [SerializeField]
    TMP_InputField userNameInputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CreateProfilAndPlay()
    {
        if (userNameInputField.text.Length==0 )return;
       UserProfile profile = UserHolder.Instance.CreateUser(userNameInputField.text);
        UserHolder.Instance.SetActiveUser(profile);
        MainMenusControler.Instance.LoadGame();
    }
    
}
