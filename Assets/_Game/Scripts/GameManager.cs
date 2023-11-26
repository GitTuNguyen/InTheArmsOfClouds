using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
        SceneManager.LoadScene("MainMenu");
    }

    public void ClearConsequenceData()
    {
        currentConsequnce = null;
    }
}
