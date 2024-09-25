using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileCreationMenu : MonoBehaviour
{
    [SerializeField]
    TMP_InputField userNameInputField;
    public void CreateProfilAndPlay()
    {
        // si linput et remplit alor créé soon profile activer le profile et charger le jeux
        if (userNameInputField.text.Length==0 )return;
       UserProfile profile = UserHolder.Instance.CreateUser(userNameInputField.text);
        UserHolder.Instance.SetActiveUser(profile);
        MainMenusControler.Instance.LoadGame();
    }
    
}
