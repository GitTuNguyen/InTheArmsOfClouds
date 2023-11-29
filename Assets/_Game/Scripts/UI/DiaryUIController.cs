using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryUIController : MonoBehaviour
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
        RefreshArtwork("",  true);
    }
    public void SetupDairyMenu()
    {
        for (int i = 0; i < DiaryManager.Instance.diaryContainer.Count; i++)
        {
            GameObject dairyMenuItem = Instantiate(dairyMenuItemPrefab, dairyMenuList.transform);
            DiaryMenuUI dairyMenuUI = dairyMenuItem.GetComponent<DiaryMenuUI>();
            if (dairyMenuUI != null)
            {
                dairyMenuUI.SetupDiaryMenuData(DiaryManager.Instance.diaryContainer[i].className, this);
            }
        }
    }

    public void RefreshArtwork(string diaryClassName, bool isFirstTimeResfresh = false)
    {        
        ClearUI();
        if (isFirstTimeResfresh)
        {
            DiaryMenuUI dairyMenuUI = dairyMenuList.transform.GetChild(0)?.GetComponent<DiaryMenuUI>();
            if (dairyMenuUI != null)
            {
                dairyMenuUI.RefreshArtworkList();
            }
        } else {
            List<ConsequenceData> consequenceList = DiaryManager.Instance.GetConsequenceDataByClassName(diaryClassName);
            if (consequenceList.Count > 0)
            {
                for (int i = 0; i < consequenceList.Count; i++)
                {
                    GameObject artworkItem = Instantiate(artworkPrefab, artworkList.transform);
                    DiaryArtworkUI artwork = artworkItem.transform.GetComponent<DiaryArtworkUI>();
                    if (artwork != null)
                    {
                        artwork.SetArtwork(consequenceList[i].artwork);
                    }
                }
            }
        }
        // Debug.Log("Set up ArtWorkList");
        // for (int i = 0; i < 4; i++)
        // {
        //     GameObject artworkItem = Instantiate(artworkPrefab, artworkList.transform);
        //     Image artworkImage = artworkItem.transform.GetChild(0).GetComponent<Image>();
        //     if (artworkImage != null)
        //     {
        //         Debug.Log("Set artwork image");
        //     }
        // }
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
