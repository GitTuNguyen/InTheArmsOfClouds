using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPhaseUIManager : MonoBehaviour
{
    public static ActionPhaseUIManager Instance;

    //UI Prefabs    
    public GameObject diaryPopup;
    public GameObject processtionPopup;
    public GameObject craftPopup;
    public GameObject rollDicePopup;
    public GameObject eventSelectionPopup;
    public GameObject eventConsequencesLoadingPopup;
    public GameObject eventConsequencesPopup;
    public GameObject findSpaceshipPopup;
    public GameObject artWorkView;

    
    public GameObject currentPopup;
    public Canvas UIHolder;
    public GameObject panel;
    public GameObject panelDetectClick;

    public float waitingLoadingTime = 3f;

    //Player Stats UI
    public Slider healthBar;
    public Slider luckBar;
    public Slider sanityBar;

    //UI manager
    public InventoryUIManager inventoryUIManager;

    
    //Spaceship
    public TMPro.TextMeshProUGUI spaceshipQuarity;
    
    private void Start() {
        if (Instance == null)
        {
            Instance = this;
        }
        RefreshSpaceShipQuarity(0, 4);
        ToggeleStatBarAtice();
    }
    

    private void SpawnPopup(GameObject popup)
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
        currentPopup = Instantiate(popup, UIHolder.transform);
        TogglePanel();
    }   

    

    public void OpenCraftPopup()
    {
        SpawnPopup(craftPopup);
    }

    public void OpenRollDicePopup()
    {
        SpawnPopup(rollDicePopup);
    }

    public void OpenDiaryPopup()
    {
        SpawnPopup(diaryPopup);
    }

    public void OpenFindSpaceshipPopup()
    {
        SpawnPopup(findSpaceshipPopup);
    }

    public void OpenArtworkView()
    {
        SpawnPopup(artWorkView);
    }

    public void OpenProcesstionPopup()
    {
        SpawnPopup(processtionPopup);
    }

    public void RefreshSpaceShipQuarity(int currentQuarity, int maxQuarity)
    {
        spaceshipQuarity.text = currentQuarity.ToString() + "/" + maxQuarity.ToString();
    }

    //Event UI
    // ninh.nghiemthanh: Trigger event
    public void TriggerEvent(EventData eventData)
    {
        Debug.Log("Trigger event UI");
        OpenEventSelectionPopup();
        EventSelectionUIController eventSelectionUIController = currentPopup.GetComponent<EventSelectionUIController>();
        if (eventSelectionUIController != null)
        {
            eventSelectionUIController.SetEventData(eventData);
        }
    }
    
    public void OpenEventSelectionPopup()
    {
        SpawnPopup(eventSelectionPopup);
    }

    public void StartConsequencesLoading()
    {
        StartCoroutine(LoadConsequences());
    }

    IEnumerator LoadConsequences()
    {
        SpawnPopup(eventConsequencesLoadingPopup);
        yield return null;
        yield return new WaitForSeconds(waitingLoadingTime);
        SpawnPopup(eventConsequencesPopup);
        EventConsequenceUI eventConsequenceUI = currentPopup?.GetComponent<EventConsequenceUI>();
        if (eventConsequenceUI != null)
        {
            eventConsequenceUI.SetConsequenUIData(GameManager.Instance.CurrentConsequnce);
        }
    }

    public void AddToInventory(InventorySlot inventorySlot, int index)
    {
        inventoryUIManager.AddToInventory(inventorySlot, index);
    }

    //Button
    public void OnResumeButtonPress()
    {
        Debug.Log("Button Resume pressed");
        GameManager.Instance.GameResume();
    }

    public void OnQuitButtonPressed()
    {
        GameManager.Instance.QuitToMenu();
    }

    //Player stats bar
    private void ToggeleStatBarAtice()
    {
        healthBar.enabled = !healthBar.enabled;
        luckBar.enabled = !luckBar.enabled;
        sanityBar.enabled = !sanityBar.enabled;
    }

    //Refresh UI
    public void RefreshPlayerStatsUI(float currentHealthPercent, float currentLuckPercent, float currentSanityPercent)
    {
        ToggeleStatBarAtice();
        healthBar.value = currentHealthPercent;
        luckBar.value = currentLuckPercent;
        sanityBar.value = currentSanityPercent;
        ToggeleStatBarAtice();
    }

    public void RefreshInventoryUI()
    {
        inventoryUIManager.RefreshInventoryUI();
    }

    public void TogglePanel (bool isPanelDetectClick = false)
    {
        if (isPanelDetectClick)
        {
            panelDetectClick.SetActive(!panelDetectClick.activeSelf);
        } else {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void CloseCurrentPopup()
    {
        if (currentPopup != null)
        {
            PopupAnimationController popupAnimationController = currentPopup.GetComponent<PopupAnimationController>();
            if (popupAnimationController != null)
            {
                popupAnimationController.ClosePopup();
            }
        }
        panel.SetActive(false);
        panelDetectClick.SetActive(false);
    }
}
