
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //Player
    public Player player;
    //Consequence 
    private ConsequenceData  currentConsequnce;
    public ConsequenceData  CurrentConsequnce 
    {
        get => currentConsequnce; 
        set 
        {
            if (currentConsequnce == null)
            {
                currentConsequnce = value;
            }
        }
    }

    private void Start() {
        if (Instance == null)
        {
            Instance = this;
        }
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
        GameResume();
        SceneManager.LoadScene("MainMenu");
    }

    public void ClearConsequenceData()
    {
        currentConsequnce = null;
    }

    public void ResetGame(bool isKeepPosition = false)
    {
        Debug.Log("Reset game");
        if (!isKeepPosition)
        {
            player.transform.position = Vector3.zero;
        }
        ResetPlayerStats();
    }

    public void ResetPlayerStats()
    {
        player.ResetPlayerStats();
    }
}
