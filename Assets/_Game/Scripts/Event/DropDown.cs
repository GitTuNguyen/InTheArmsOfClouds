using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DropDown : MonoBehaviour
{
    public TextMeshProUGUI title;
    public EventData seaSO;
    public EventData woodSO;
    /*public EventData desertSO;
    public EventData grassSO;*/
    public TextMeshProUGUI eventDes;
    public List<TextMeshProUGUI> optionDesList;
    List<OptionData> optionList;

    public void _DropDown(int eventBlock)
    {
        switch(eventBlock) 
        {
            case 0: 
                title.text = "SEA";
                eventDes.text = seaSO.EventDescription;
                optionList = seaSO.Options;
                Debug.LogFormat("event of sea block has {0} options", optionList.Count);
                int index = 0;
                foreach (TextMeshProUGUI optionDes in optionDesList)
                {
                    if (index < optionList.Count)
                    {
                        optionDes.text = optionList[index].OptionDescription;
                        ++index;
                    }
                    else
                    {
                        Transform optionButton = optionDes.transform.parent;
                        optionButton.gameObject.SetActive(false);
                    }
                }    
                break;
            case 1:
                title.text = "WOOD";
                eventDes.text = seaSO.EventDescription;
                optionList = woodSO.Options;
                Debug.LogFormat("event of wood block has {0} options", optionList.Count);
                index = 0;
                foreach (TextMeshProUGUI optionDes in optionDesList)
                {
                    if (index < optionList.Count)
                    {
                        optionDes.text = optionList[index].OptionDescription;
                        ++index;
                    }
                    else
                    {
                        Transform optionButton = optionDes.transform.parent;
                        optionButton.gameObject.SetActive(false);
                    }
                }
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
