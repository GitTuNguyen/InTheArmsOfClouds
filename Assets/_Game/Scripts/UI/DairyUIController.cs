using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DairyUIController : MonoBehaviour
{
    public GameObject dairyMenuItemPrefab;
    public GameObject dairyMenuList;
    public int dairyMenuAmount = 4;
    
    public GameObject artworkList;
    public GameObject artworkPrefab;
    public GameObject currentDairyMenu;
    // Start is called before the first frame update
    void Start()
    {
        SetupDairyMenu();
    }
    public void SetupDairyMenu()
    {
        for (int i = 0; i < dairyMenuAmount; i++)
        {
            GameObject dairyMenuItem = Instantiate(dairyMenuItemPrefab, dairyMenuList.transform);
            DairyMenuUI dairyMenuUI = dairyMenuItem.GetComponent<DairyMenuUI>();
            if (dairyMenuUI != null)
            {
                dairyMenuUI.menuName.text = "Dairy menu";
                dairyMenuUI.dairyUIController = this;
            }
        }
    }

    public void SetupArtworkList()
    {        
        ClearUI();
        Debug.Log("Set up ArtWorkList");
        for (int i = 0; i < 4; i++)
        {
            GameObject artworkItem = Instantiate(artworkPrefab, artworkList.transform);
            Image artworkImage = artworkItem.transform.GetChild(0).GetComponent<Image>();
            if (artworkImage != null)
            {
                Debug.Log("Set artwork image");
            }
        }
    }

    private void ClearUI()
    {
        if (artworkList.transform.childCount > 0)
        {
            foreach (Transform artworkSlot in artworkList.transform)
            {
                Destroy(artworkSlot.gameObject);
            }
        }
    }
}
