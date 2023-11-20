using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DropDown : MonoBehaviour
{
    public TextMeshProUGUI title;
    public EventData seaSO;
    /*public EventData woodSO;
    public EventData desertSO;
    public EventData grassSO;*/
    public TextMeshProUGUI eventDes;
    public List<TextMeshProUGUI> optionDesList = new List<TextMeshProUGUI>();

    public void _DropDown(int eventBlock)
    {
        switch(eventBlock) 
        {
            case 0:
                title.text = "SEA";
                eventDes.text = seaSO.EventDescription;
                foreach(OptionData optionData in seaSO.Options)
                {
                    optionDesList[optionData.OptionId].text = optionData.OptionDescription;
                    
                }    
                break;
            case 1:
                title.text = "WOOD";
                break;
            case 2:
                title.text = "DESERT";
                break;
            case 3:
                title.text = "GRASS";
                break;
        }
    }
}
