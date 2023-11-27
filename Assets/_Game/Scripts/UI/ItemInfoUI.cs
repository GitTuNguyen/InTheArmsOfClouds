using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI infoPopupItemName;
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
        if (itemData.healthItem > 0)
        {
            SpawnEffectTF(itemData.healthItem, "Health");
        }
        if (itemData.healthItem > 0)
        {
            SpawnEffectTF(itemData.luckItem, "Luck");
        }
        if (itemData.healthItem > 0)
        {
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
