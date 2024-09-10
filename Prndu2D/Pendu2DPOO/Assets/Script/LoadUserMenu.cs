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
        List<string> users = UserHolder.Instance.GetAllUsers();
        foreach (string user in users)
        { 
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(slotParent, false);

            UserSlotController slotControler = slotInstance.GetComponent<UserSlotController>();
            slotControler.SetUser(user);
        }
    }
}
