
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

    [Header("Game Play")]
    public int currentDiceNumber;

    //Player
    public Player player;

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
        SFXManager.Instance.StopAllSound();
        ClearMainMenu();
        GameResume();
        SceneManager.LoadScene(sceneName);
        InitActionPhase();
        SFXManager.Instance.PlaySound("BackgroundMusic");
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
        ClearActionPhase();
        SceneManager.LoadScene("MainMenu");
        InitMainMenu();
    }

    //Init
    private void InitMainMenu()
    {
        MainMenuUIController = Instantiate(MainMenuUIControllerPrefab, Vector3.zero, Quaternion.identity);
    }

    private void InitActionPhase()
    {
        ActionPhaseUIController = Instantiate(ActionPhaseUIControllerPrefab, transform);
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
        player.ResetPlayerStats();
    }

    //Game state
    public void GameOver()
    {
        GamePause();
        ActionPhaseUIManager.Instance?.OpenGameOverView();
    }

    public void GameFinished()
    {
        GamePause();
        ActionPhaseUIManager.Instance?.OpenWinView();
    }
}
