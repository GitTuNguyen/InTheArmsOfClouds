using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIController : MonoBehaviour
{
    public Animator MainMenuAnimator;
    public GameObject panel;
    private void Start() {
        SFXManager.Instance.PlaySound("Raining");
    }

    private void Update() {
        if (panel != null && !AnimatorIsPlaying())
        {
            Destroy(panel);
        }
    }
    public void StartGame(string sceneName)
    {
        SFXManager.Instance.StopSound("Raining");
        GameManager.Instance.StartGame(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game UI");
        GameManager.Instance.QuitGame();
    }

    public void PlayMainUIAnimation()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        if (MainMenuAnimator != null)
        {
            Debug.Log("Play Main UI Animation");
            MainMenuAnimator.SetTrigger("StartGame");
        } else {
            Debug.LogError("Mainmenu animator null");
        }
    }

    public void SkipAnimation()
    {
        if (MainMenuAnimator != null && AnimatorIsPlaying() )
        {
            Debug.Log("Skip Main UI Animation");
            if (panel != null)
            {
                Destroy(panel);
            }
            MainMenuAnimator.Play("MainMenuUI", 0, 1.0f);
        } else {
            Debug.LogError("Mainmenu animator null");
        }
    }
    bool AnimatorIsPlaying(){
    return MainMenuAnimator.GetCurrentAnimatorStateInfo(0).length >
           MainMenuAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
