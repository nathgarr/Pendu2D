using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    public void Restart()
    {
        // restore la scene
        SceneManager.LoadScene("Pendu");
    }
    public void Back()
    {
        //renvoy au menu
        SceneManager.LoadScene("MainMenu");
    }
}
