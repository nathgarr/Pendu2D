using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfflineSelectionMenu : MonoBehaviour
{
    [SerializeField]
    Button onlineBtn;
    // Start is called before the first frame update
    void Start()
    {
        CheckInternetConection();
    }
    void CheckInternetConection()
    {
        // si ya internet deverouille le bouton
        onlineBtn.interactable = Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
    }
}
