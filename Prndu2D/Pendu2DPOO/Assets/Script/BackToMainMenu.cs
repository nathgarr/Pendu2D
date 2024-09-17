using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu , actualMenu;
   
    public void GoBackToMainMenu()
    {
        mainMenu.SetActive(true);
        actualMenu.SetActive(false);
    }
}
