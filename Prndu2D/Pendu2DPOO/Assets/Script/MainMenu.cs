using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenusControler : MonoBehaviour
{
    public static MainMenusControler Instance;
    [SerializeField]
    GameObject loadMenu, creationMenu, selection;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadGame()
    {
        // chargement de la scene de jeux
        SceneManager.LoadScene(1);
    }
   public void DisplayLoadProfileMenu(bool value)
    {
        // faire aparaitre load menu et desactive selection
        loadMenu.SetActive(value);
        selection.SetActive(false);
    }
    public void DisplayCreationProfileMenu(bool value)
    {
        // faire aparaitre le menu creation de compte et fermer selection menu
        creationMenu.SetActive(value);
        selection.SetActive(false);
    }

    public void Quit()
    {
        // permet de fermer le jeux 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_STANDALONE
        Application.Quit();
#endif
    }

}
