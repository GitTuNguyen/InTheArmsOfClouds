using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenuController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _menuName;
    public CraftableItem _craftItem;
    [SerializeField] 
    private CraftUIController _craftUIController;
    
    public void RefreshCraftView()
    {
        if (_craftItem != null)
        {
            _craftUIController.RefreshCraftView(_craftItem);
        }        
    }

    public void SetupCraftMenuData(CraftableItem craftableItem, CraftUIController craftUIController)
    {
        _menuName.text = craftableItem.name;
        _craftItem = craftableItem;
        _craftUIController = craftUIController;
    }
}
