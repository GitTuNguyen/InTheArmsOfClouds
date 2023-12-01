using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI infoPopupItemName;
    public TMPro.TextMeshProUGUI infoPopupItemDesc;
    public GameObject itemEffectListHolder;
    public GameObject effectTFPrefabs;

    public void SetItemInfoData(InventoryItemData itemSlotData)
    {
        Debug.Log("set item info");
        infoPopupItemName.text = itemSlotData.nameItem;
        SetItemEffect(itemSlotData);
    }

    private void SetItemEffect(InventoryItemData itemData)
    {
        Debug.Log("Set Item Effect");
        if (!string.IsNullOrEmpty(itemData.description))
        {
            infoPopupItemDesc.gameObject.SetActive(true);
            infoPopupItemDesc.text = itemData.description;
            return;
        }

        if (itemData.healthItem > 0)
        {
            Debug.Log("Item info Health: " + itemData.healthItem);
            SpawnEffectTF(itemData.healthItem, "Health");
        }

        if (itemData.luckItem > 0)
        {
            Debug.Log("Item info Luck: " + itemData.luckItem);
            SpawnEffectTF(itemData.luckItem, "Luck");
        }

        if (itemData.sanityItem > 0)
        {
            Debug.Log("Item info Sanity: " + itemData.sanityItem);
            SpawnEffectTF(itemData.sanityItem, "Sanity");
        }
    }

    private void SpawnEffectTF(int stat, string effectName)
    {
        var effect = Instantiate(effectTFPrefabs, itemEffectListHolder.transform);
        if (effectName != null)
        {
            TMPro.TextMeshProUGUI effectTF = effect.GetComponent<TextMeshProUGUI>();
            if (effectTF != null)
            {
                effectTF.text = "+" + stat.ToString() + " " + effectName;
            }
        }
    }
}
