using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlotUI : MonoBehaviour
{
    public GameObject icon;
    public TextMeshProUGUI text;

    private void Start()
    {
        
    }

    public void ResetInventorySlotUI()
    {
        icon.GetComponent<Image>().sprite = null;
        text.text = "x0";
    }

    public void UpdateInventorySlot(InventoryItemData  item, int number)
    {
        icon.GetComponent<UnityEngine.UI.Image>().sprite = item.icon;
        text.text = "x" + number.ToString();
    }
}
