using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Pendu");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
