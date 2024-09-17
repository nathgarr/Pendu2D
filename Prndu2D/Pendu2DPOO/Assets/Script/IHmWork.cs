using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHmWork : MonoBehaviour
{
    public static IHmWork Instance;
    [SerializeField]
    GameObject   musicSettingPanel;
    private void Awake()
    {
        Instance = this;
    }
    // ouvrire music setting
    public void Open()
    {
        musicSettingPanel.SetActive(true);
    }
    // fermer music setting
    public void Close () 
    {
        musicSettingPanel.SetActive(false);
    }
}
