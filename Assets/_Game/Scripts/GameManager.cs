using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

}
