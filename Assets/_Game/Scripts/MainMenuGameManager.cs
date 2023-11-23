using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Tu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //stop play in Unity editor
#endif
        Application.Quit();
    }
}
