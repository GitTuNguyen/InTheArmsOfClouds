using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenuController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI menuName;
    public CraftUIController craftUIController;
    public GameObject craftItem;
    
    public void RefreshCraftView()
    {
        craftUIController.RefreshCraftView(craftItem);
    }
}
