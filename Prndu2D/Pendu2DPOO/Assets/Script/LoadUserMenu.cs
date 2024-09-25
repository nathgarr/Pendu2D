using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUserMenu : MonoBehaviour
{
    [SerializeField]
    GameObject slotPrefab;
    [SerializeField]
    RectTransform slotParent;
    // Start is called before the first frame update
    void Start()
    {
        CreateSlot();
    }

    public void CreateSlot()
    {
        // recupéré et ajouter a la liste les user sauvegarder
        List<string> users = UserHolder.Instance.GetAllUsers();
        foreach (string user in users)
        { 
            // crée physiquement le slot prefab et lui ajouter un parent
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(slotParent, false);

            //mettre le user actif avec le bon nom
            UserSlotController slotControler = slotInstance.GetComponent<UserSlotController>();
            slotControler.SetUser(user);
        }
    }
}
