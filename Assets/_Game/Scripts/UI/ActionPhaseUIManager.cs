using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //UI holder
    public GameObject currentPopup;
    public Canvas UIHolder;
    public GameObject panel;
    public GameObject panelDetectClick;
    public List<GameObject> actionPhaseUIList;

    //Menu view
    public GameObject pauseMenu;
    public GameObject youWinView;
    public GameObject thatAllView;
    public GameObject gameoverView;

    public float waitingLoadingTime = 3f;

    //Player Stats UI
    public Slider healthBar;
    public Slider luckBar;
    public Slider sanityBar;

    //UI manager
    public InventoryUIManager inventoryUIManager;

    
    //Spaceship
    public TMPro.TextMeshProUGUI spaceshipQuarity;

    public GameObject dice;
    public Button rollDiceButton;

    //Cheat
    public GameObject cheatMenu;
    public TMPro.TextMeshProUGUI playerSpeedCheatButtonText;
    public TMPro.TextMeshProUGUI SkipLoadingEventText;
    bool isSkipLoadingEvent = false;
    
    
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable() {
        
        RefreshSpaceShipQuarity();
        ToggeleStatBarAtice();

    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.C))
        {
            cheatMenu.SetActive(!cheatMenu.activeSelf);
        }
    }

    public void StartActionPhaseUI()
    {
        foreach(GameObject gameObject in actionPhaseUIList)
        {
            gameObject.SetActive(true);
            if (!GameManager.Instance.enableDice)
            {
                dice.gameObject.SetActive(false);
            }
        }
    }
    

    private void SpawnPopup(GameObject popup)
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
        currentPopup = Instantiate(popup, UIHolder.transform);
        if (!panel.activeSelf)
        {
            TogglePanel();
        }
    }

    //Open Popup
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

    //Menu    
    public void TogglePauseView()
    {
        TogglePanel();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void OpenWinView()
    {        
        TogglePanel();
        youWinView.SetActive(true);
    }

    public void OpenThatAllView()
    {
        youWinView.SetActive(false);
        thatAllView.SetActive(true);
    }
    public void OpenGameOverView()
    {
        gameoverView.SetActive(true);
    }

    //Spaceship
    public void RefreshSpaceShipQuarity()
    {
        if (InventoryHolder.Instance?.InventorySystem == null)
        {
            spaceshipQuarity.text = 0.ToString() + "/"+ 4.ToString();
        } else {
            spaceshipQuarity.text = InventoryHolder.Instance.InventorySystem.spaceShipPiece.ToString() + "/" + InventoryHolder.Instance.InventorySystem.SpaceShipPieceMax.ToString();
        }
        
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
        SFXManager.Instance?.PlaySound("ConsequenceInOut");
        SpawnPopup(eventSelectionPopup);
    }

    public void StartConsequencesLoading()
    {
        StartCoroutine(LoadConsequences());
    }

    IEnumerator LoadConsequences()
    {
        if (!isSkipLoadingEvent)
        {
            SpawnPopup(eventConsequencesLoadingPopup);
            yield return new WaitForSeconds(waitingLoadingTime);
        } else {
            yield return null;
        }
        
        SpawnPopup(eventConsequencesPopup);
        EventConsequenceUI eventConsequenceUI = currentPopup?.GetComponent<EventConsequenceUI>();
        if (eventConsequenceUI != null)
        {
            eventConsequenceUI.SetConsequenUIData(GameEventSystem.Instance.CurrentConsequnce);
        }
    }

    public void AddToInventory(InventorySlot inventorySlot, int index)
    {
        inventoryUIManager.AddToInventory(inventorySlot, index);
    }

    //Button
    public void OnResumeButtonPressed()
    {
        GameManager.Instance.GameResume();
        TogglePauseView();
    }

    public void OnReplayButtonPressed()
    {
        gameoverView?.SetActive(false);
        GameManager.Instance.ResetGame();
    }
    public void OnQuitButtonPressed()
    {
        Destroy(healthBar);
        Destroy(luckBar);
        Destroy(sanityBar);
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
    public void RefreshPlayerStatsUI(int currentHealth, int currentLuck, int currentSanity)
    {
        ToggeleStatBarAtice();
        healthBar.value = currentHealth;
        luckBar.value = currentLuck;
        sanityBar.value = currentSanity;
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

    public void OnFindSpaceshipPopupClose()
    {
        if(GameManager.Instance.isGameFinished)
        {
            OpenWinView();
        }
    }
    //Item
    public void OnItemClick(int index)
    {
        InventoryHolder.Instance.InventorySystem.UsingItemAtSlot(index);
    }

    //Cheat
    public void KillPlayer()
    {
        GameManager.Instance?.player.UpdateStatsOfPlayer(-5,-5,-5);
    }
    public void AddShield()
    {
        GameManager.Instance?.player.AddShield();
    }
    public void SetPlayerSpeed()
    {
        int currentPlaySpeed = GameManager.Instance.SetPlayerSpeed();
        playerSpeedCheatButtonText.text = "Player Speed: x" + currentPlaySpeed.ToString();
    }
    public void ToggleSkipLoadingEvent()
    {
        isSkipLoadingEvent = !isSkipLoadingEvent;
        SkipLoadingEventText.text = "Skip Loading Event: ";
        if (isSkipLoadingEvent)
        {
            SkipLoadingEventText.text += "ON";
        } else {
            SkipLoadingEventText.text += "OFF";
        }
    }
}
