using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftUIController : MonoBehaviour
{
    public GameObject craftMenuItemPrefab;
    public GameObject craftMenuList;
    public CraftableItem craftItemSlelected;
    
    public GameObject materialList;
    public GameObject materialPrefab;
    
    public GameObject effectList;
    public GameObject effectTFPrefab;
    public GameObject craftItemDescTFPrefab;

    public GameObject craftButtonOn;
    public GameObject craftButtonOff;

    public Image itemCraftImage;
    public TMPro.TextMeshProUGUI itemCraftQuarity;
    //test
    public Sprite materialSpriteTest;
    public Sprite craftItemSpriteTest;
    public int craftItemQuarityTest;
    public int effectAmountTest = 3;
    // Start is called before the first frame update
    void Start()
    {
        SetupCraftMenu();

    }
    public void SetupCraftMenu()
    {
        for (int i = 0; i < CrafItemManager.Instance.craftableItemsList.Count; i++)
        {
            GameObject craftMenuItem = Instantiate(craftMenuItemPrefab, craftMenuList.transform);
            CraftMenuController craftyMenuUI = craftMenuItem.GetComponent<CraftMenuController>();
            if (craftyMenuUI != null)
            {
                Debug.Log("Setup " + CrafItemManager.Instance.craftableItemsList[i].name + "menu");
                craftyMenuUI.SetupCraftMenuData(CrafItemManager.Instance.craftableItemsList[i], this);
            }
        }
        CraftMenuController firstCraftMenuUI = craftMenuList.transform.GetChild(0)?.GetComponent<CraftMenuController>();
        if (firstCraftMenuUI != null)
        {
            firstCraftMenuUI.RefreshCraftView();
        }
    }
    public void RefreshCraftView(CraftableItem craftableItem)
    {
        ClearUI();
        craftItemSlelected = craftableItem;
        if (craftableItem.crafItem == null)
        {
            Debug.Log("No item was set");
            return;
        }
        for (int i = 0; i < craftItemSlelected.materialList.Count; i++)
        {
            GameObject material = Instantiate(materialPrefab, materialList.transform);
            CraftMaterialUI craftMaterialUI = material.GetComponent<CraftMaterialUI>();
            InventoryItemData currentMaterial = craftItemSlelected.materialList[i].item;
            if (craftMaterialUI != null && currentMaterial != null)
            {
                craftMaterialUI.SetupMaterial(currentMaterial.icon, InventoryHolder.Instance.InventorySystem.GetAmountItemInInventory(currentMaterial), craftItemSlelected.materialList[i].amountRequired);
                Debug.Log("Set material image");
            }
        }
        itemCraftImage.sprite = craftItemSlelected.crafItem.icon;
        itemCraftQuarity.text = InventoryHolder.Instance.InventorySystem.GetAmountItemInInventory(craftItemSlelected.crafItem).ToString();
        
        // for (int i = 0; i < craftItemSlelected.crafItem.; i++)
        // {
        //     GameObject effectTF = Instantiate(effectTFPrefab, effectList.transform);
        //     TextMeshProUGUI effectText = effectTF.GetComponent<TextMeshProUGUI>();
        //     effectText.color = Color.green;
        //     effectText.text = "+" + i.ToString() + "Health";
        // }
        InventoryItemData currentCraftItem = craftItemSlelected.crafItem;
        if (String.IsNullOrEmpty(currentCraftItem.description))
        {
            if (currentCraftItem.healthItem > 0)
            {
                GameObject effectTF = Instantiate(effectTFPrefab, effectList.transform);
                TextMeshProUGUI effectText = effectTF.GetComponent<TextMeshProUGUI>();
                effectText.text = "+" + currentCraftItem.healthItem.ToString() + "Health";
            }
            if (currentCraftItem.luckItem > 0)
            {
                GameObject effectTF = Instantiate(effectTFPrefab, effectList.transform);
                TextMeshProUGUI effectText = effectTF.GetComponent<TextMeshProUGUI>();
                effectText.text = "+" + currentCraftItem.luckItem.ToString() + "Luck";
            }
            if (currentCraftItem.sanityItem > 0)
            {
                GameObject effectTF = Instantiate(effectTFPrefab, effectList.transform);
                TextMeshProUGUI effectText = effectTF.GetComponent<TextMeshProUGUI>();
                effectText.text = "+" + currentCraftItem.sanityItem.ToString() + "Sanity";
            }
        } else {
            GameObject effectTF = Instantiate(craftItemDescTFPrefab, effectList.transform);
            TextMeshProUGUI craftItemDescTF = effectTF.GetComponent<TextMeshProUGUI>();
            craftItemDescTF.text = currentCraftItem.description;
        }
        if (CrafItemManager.Instance.IsItemCanBeCrafted(craftItemSlelected))
        {
            Debug.Log("can be craft");
            craftButtonOff.SetActive(false);
            craftButtonOn.SetActive(true);
        } else {
            Debug.Log("can't be craft");
            craftButtonOff.SetActive(true);
            craftButtonOn.SetActive(false);
        }
    }

    private void ClearUI()
    {
        if (materialList.transform.childCount > 0)
        {
            Debug.Log("Clear material list");
            foreach (Transform materialSlot in materialList.transform)
            {
                Destroy(materialSlot.gameObject);
            }
        }
        if (effectList.transform.childCount > 0)
        {
            Debug.Log("Clear material list");
            foreach (Transform effectSlot in effectList.transform)
            {
                Destroy(effectSlot.gameObject);
            }
        }
    }

    public void OnCraftButtonPress()
    {
        CrafItemManager.Instance.CraftItem(craftItemSlelected);
        RefreshCraftView(craftItemSlelected);
    }
}
