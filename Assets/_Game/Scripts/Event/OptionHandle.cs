using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        int index = Random.Range(0,optionData.Consequences.Count);
        if (optionData != null)
        {
            Debug.LogFormat("Option Description: {0}", optionData.OptionDescription);
            artwork.GetComponent<SpriteRenderer>().sprite = optionData.Consequences[index].artwork;
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
