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
        SceneManager.LoadScene(0);
    }
   public void DisplayLoadProfileMenu(bool value)
    {
        loadMenu.SetActive(value);
        selection.SetActive(false);
    }
    public void DisplayCreationProfileMenu(bool value)
    {
        creationMenu.SetActive(value);
        selection.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_STANDALONE
        Application.Quit();
#endif
    }

}
