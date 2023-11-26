using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

// This script just use in Ninh's demo
public class OptionHandle : MonoBehaviour
{
    [SerializeField]
    private OptionData optionData;
    public OptionData OptionData
    {
        get { return optionData; }
        set { optionData = value; }
    }

    [SerializeField]
    private GameObject artwork;   

    public void BtnOption()
    {
        if (optionData != null)
        {
            ConsequenceData consequenceTriggered = optionData.TriggerOption();
            Debug.LogFormat("Option Description: {0}", optionData.OptionDesc);
            artwork.GetComponent<SpriteRenderer>().sprite = consequenceTriggered.artwork;
            Debug.LogFormat("Consequence: {0}", consequenceTriggered.consequenceCode);
            artwork.SetActive(true);
        }
        else
        {
            Debug.Log("Option Data is empty");
        }

    }

    public void BtnX()
    {
        artwork.SetActive(false);   
    }
}
