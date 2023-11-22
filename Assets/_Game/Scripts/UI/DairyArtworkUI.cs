using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DairyArtworkUI : MonoBehaviour
{
    public Sprite artworkImage;
    public void ShowArtworkView()
    {
        ActionPhaseUIManager.Instance.OpenArtworkView();
        GameObject artworkView = ActionPhaseUIManager.Instance.currentPopup;
        Image artwork =  artworkView.transform.GetChild(0).GetComponent<Image>();
        if (artwork != null)
        {
            artwork.sprite = artworkImage;
            Debug.Log("Set Art work image DairyArtworkUI");
        }
    }
}
