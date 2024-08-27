using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHpHud : MonoBehaviour
{
    public static PlayerHpHud Instance;
    [SerializeField]
    public GameObject gameOverMenus;
    [SerializeField] TextMeshProUGUI Eror_Left;
    int MaxLife = 6;
    int Life = 0;
    private void Awake()
    {
        Instance = this;
    }
    // si le joueur se trompe enlever 1 tentative une foi les tentative epuiser faire aparaitre  le menu game over pour relancer le jeux
    public void PlayerErorLeft()
    {
        if (Life <= MaxLife)
        {
            MaxLife--;

            Eror_Left.text = "Player Try Left" + " " + MaxLife.ToString();
            if (MaxLife == 0)
            {
                gameOverMenus.SetActive(true);
            }
        }
    }
}
