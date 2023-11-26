using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventConsequenceUI : MonoBehaviour
{
    public GameObject consequenceEffectTFPrefab;
    public Image artwork; 
    public Transform effectListHolder;

    public void SetConsequenUIData(ConsequenceData consequenceData)
    {
        artwork.sprite = consequenceData.artwork;
        for (int i = 0; i < consequenceData.effectDescriptions.Count; i++)
        {
            ConsequenceEffectUI consequenceEffectUI = Instantiate(consequenceEffectTFPrefab, effectListHolder)?.GetComponent<ConsequenceEffectUI>();
            if (consequenceEffectUI != null)
            {
                consequenceEffectUI.SetConsequenseEffect(consequenceData.effectDescriptions[i].effectStat, consequenceData.effectDescriptions[i].effectDesc);
            }
        }
    }

    public void CloseConsequenPopup()
    {
        GameManager.Instance.ClearConsequenceData();
    }
}
