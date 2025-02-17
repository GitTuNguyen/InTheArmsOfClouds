
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefabs")]
    public GameObject MainMenuUIControllerPrefab;
    public GameObject ActionPhaseUIControllerPrefab;
    public GameObject CraftSystemPrefab;
    public GameObject InventorySystemPrefab;
    public GameObject DiarySystemPrefab;
    public GameObject EventSystemPrefab;

    [Header("GameManager")]
    public GameObject MainMenuUIController;
    public GameObject ActionPhaseUIController;
    public GameObject CraftSystem;
    public GameObject InventorySystem;
    public GameObject DiarySystem;
    public GameObject EventSystem;

    //Scene
    public string mainMenuSceneName = "MainMenu";

    [Header("Game Play")]
    public int currentDiceNumber;
    public bool isGameFinished;
    public int currentPlayerMultiplesSpeed = 1;
    public int maxPlayerMultiplesSpeed = 3;

    //Player
    public Player player;
    public CharacterStateMachine characterStateMachine;
    public PlayerStateManager playerStateManager;

    public bool enableDice;
    
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        Debug.Log("GameManager Start");
        OnGameOpen();
        enableDice = true;
    }

    private void OnGameOpen()
    {
        LoadMainMenu();
        MainMenuUIController mainMenuUI = MainMenuUIController.GetComponentInChildren<MainMenuUIController>();
        if (mainMenuUI != null)
        {
            mainMenuUI.PlayMainUIAnimation();
        } else {
            Debug.Log("Can't find mainMenuUIAnimation");
        }
    }
    public void StartGame(string sceneName)
    {
        Debug.Log("Start Game");
        
        if(sceneName == "Congyon")
        {
            enableDice = false;
        } else {
            enableDice = true;
        }
        StartCoroutine(LoadActionPhaseScene(sceneName));
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //stop play in Unity editor
#endif
        Application.Quit();
    }

    public void GamePause()
    {
        Debug.Log("GamePause");
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        Debug.Log("GameResume");
        Time.timeScale = 1;
    }

    public void QuitToMenu()
    {
        
        Debug.Log("Quit To Menu");
        if (player != null)
        {
            player = null;
        }
        ClearActionPhase();
        StartCoroutine(LoadMenuScene());
        
    }

    IEnumerator LoadActionPhaseScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        InitActionPhase();
        isGameFinished = false;
        ActionPhaseUIManager.Instance?.RefreshSpaceShipQuarity();
        SFXManager.Instance.PlaySound("BackgroundMusic");
    }
    IEnumerator LoadMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuSceneName);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SFXManager.Instance.StopSound("BackgroundMusic");        
        SFXManager.Instance.PlaySound("Raining");
        //InitMainMenu();
        OnGameOpen();
    }

    //Init
    private void InitMainMenu()
    {
        MainMenuUIController = Instantiate(MainMenuUIControllerPrefab, Vector3.zero, Quaternion.identity);
    }

    private void InitActionPhase()
    {
        //ActionPhaseUIController = Instantiate(ActionPhaseUIControllerPrefab, transform);
        CraftSystem = Instantiate(CraftSystemPrefab, transform);
        InventorySystem = Instantiate(InventorySystemPrefab, transform);
        DiarySystem = Instantiate(DiarySystemPrefab, transform);
        EventSystem = Instantiate(EventSystemPrefab, transform );
    }

    public void ClearMainMenu()
    {
        Destroy(MainMenuUIController);
        MainMenuUIController = null;
    }
    private void ClearActionPhase()
    {
        Destroy(ActionPhaseUIController);
        Destroy(CraftSystem);
        Destroy(InventorySystem);
        Destroy(DiarySystem);
        Destroy(EventSystem);
        if (playerStateManager != null)
        {
            Destroy(playerStateManager.gameObject);
        } else if (characterStateMachine != null)
        {
            Destroy(characterStateMachine.gameObject);
        }
        playerStateManager = null;
        characterStateMachine = null;
        ActionPhaseUIController = null;
        CraftSystem = null;
        InventorySystem = null;
        DiarySystem = null;
    }

    public void LoadMainMenu()
    {
        InitMainMenu();
    }    

    public void ResetGame(bool isKeepPosition = false)
    {
        Debug.Log("Reset game");
        if (!isKeepPosition)
        {
            player.transform.position = Vector3.zero;
        }
        ResetPlayerStats();
        InventoryHolder.Instance.ClearInventory();
    }

    public void ResetPlayerStats()
    {
        player?.ResetPlayerStats();
    }

    //Game state
    public void GameOver()
    {
        GamePause();
        ActionPhaseUIManager.Instance?.OpenGameOverView();
    }

    public void GameFinished()
    {
        //GamePause();
        isGameFinished = true;
    }

    public int SetPlayerSpeed()
    {
        currentPlayerMultiplesSpeed += 1;
        if (currentPlayerMultiplesSpeed > maxPlayerMultiplesSpeed)
        {
            currentPlayerMultiplesSpeed = 1;
        }
        if (playerStateManager != null)
        {
            playerStateManager.playerController.SetPlayerSpeed(currentPlayerMultiplesSpeed);
        } else if (characterStateMachine != null)
        {
            characterStateMachine.playerController.SetPlayerSpeed(currentPlayerMultiplesSpeed);
        }
        return currentPlayerMultiplesSpeed;
    }
}
