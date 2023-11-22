using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftUIController : MonoBehaviour
{
    public GameObject craftMenuItemPrefab;
    public GameObject craftMenuList;
    public int craftMenuAmount = 5;
    
    public GameObject materialList;
    public GameObject materialPrefab;
    
    public GameObject effectList;
    public GameObject effectTFPrefab;

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
        for (int i = 0; i < craftMenuAmount; i++)
        {
            GameObject dairyMenuItem = Instantiate(craftMenuItemPrefab, craftMenuList.transform);
            CraftMenuController craftyMenuUI = dairyMenuItem.GetComponent<CraftMenuController>();
            if (craftyMenuUI != null)
            {
                craftyMenuUI.menuName.text = "Craft menu";
                craftyMenuUI.craftUIController = this;
            }
        }
    }
    public void RefreshCraftView(GameObject craftItem = null)
    {
        ClearUI();
        for (int i = 0; i < 3; i++)
        {
            GameObject material = Instantiate(materialPrefab, materialList.transform);
            CraftMaterialUI craftMaterialUI = material.GetComponent<CraftMaterialUI>();
            if (craftMaterialUI != null)
            {
                craftMaterialUI.SetupMaterial(materialSpriteTest, i + 1, 3);
                Debug.Log("Set material image");
            }
        }
        itemCraftImage.sprite = craftItemSpriteTest;
        itemCraftQuarity.text = 0.ToString();
        for (int i = 0; i < effectAmountTest; i++)
        {
            GameObject effectTF = Instantiate(effectTFPrefab, effectList.transform);
            TextMeshProUGUI effectText = effectTF.GetComponent<TextMeshProUGUI>();
            effectText.color = Color.green;
            effectText.text = "+" + i.ToString() + "Health";
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
}
