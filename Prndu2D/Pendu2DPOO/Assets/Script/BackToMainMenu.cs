using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu , actualMenu;
   
    public void GoBackToMainMenu()
    {
        // si je click sur le buton close renvoyer au menu d'avan
        mainMenu.SetActive(true);
        actualMenu.SetActive(false);
    }
}
