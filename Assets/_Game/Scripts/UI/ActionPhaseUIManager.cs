using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPhaseUIManager : MonoBehaviour
{
    public static ActionPhaseUIManager Instance;

    //UI Prefabs    
    public GameObject dairyPopup;
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

    public float waitingLoadingTime = 3f;

    //Player Stats UI
    public Slider healthBar;
    public Slider luckBar;
    public Slider sanityBar;
    private void Start() {
        if (Instance == null)
        {
            Instance = this;
        }
        RefreshSpaceShipQuarity(0, 4);
    }
    
    //Spaceship
    public TMPro.TextMeshProUGUI spaceshipQuarity;

    private void SpawnPopup(GameObject popup)
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
        currentPopup = Instantiate(popup, UIHolder.transform);
        panel.SetActive(true);
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
    }

    public void RefreshPlayerStatsUI(float currentHealthPercent, float currentLuckPercent, float currentSanityPercent)
    {
        healthBar.value = currentHealthPercent;
        luckBar.value = currentLuckPercent;
        sanityBar.value = currentSanityPercent;
    }

    public void OpenCraftPopup()
    {
        SpawnPopup(craftPopup);
    }

    public void OpenRollDicePopup()
    {
        SpawnPopup(rollDicePopup);
    }

    public void OpenDairyPopup()
    {
        SpawnPopup(dairyPopup);
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
        spaceshipQuarity.text = currentQuarity.ToString() + " / " + maxQuarity.ToString();
    }
}
