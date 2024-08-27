using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenusControler : MonoBehaviour
{
  
    public void LoadGame()
    {
        // chargement de la scene de jeux
        SceneManager.LoadScene(0);
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
