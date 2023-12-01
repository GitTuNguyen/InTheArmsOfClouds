using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSpaceshipPopupUI : MonoBehaviour
{
    public void OnFindSpaceshipPopupClose()
    {
        if(GameManager.Instance.isGameFinished)
        {
            ActionPhaseUIManager.Instance?.OpenWinView();
        }
    }
}
