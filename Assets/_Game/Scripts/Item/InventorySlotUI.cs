using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventorySlotUI : MonoBehaviour,IPointerClickHandler
{
    public GameObject icon;
    public TextMeshProUGUI text;
    private InventoryItemData itemUI = null;

    private Sprite none;
    private void Start()
    {
        none = icon.GetComponent<UnityEngine.UI.Image>().sprite;
    }

    public void ResetInventorySlotUI()
    {
        icon.GetComponent<UnityEngine.UI.Image>().sprite = none;
        text.text = "x0";
    }

    public void UpdateInventorySlot(InventoryItemData  item, int number)
    {
        if(number <= 0)
        {
            ResetInventorySlotUI();
            return;
        }
        icon.GetComponent<UnityEngine.UI.Image>().sprite = item.icon;
        text.text = "x" + number.ToString();
        itemUI = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(itemUI != null)
        {
            InventoryHolder.Instance.InventorySystem.RemoveToInventory(itemUI, 1,this);
        }
    }
}
