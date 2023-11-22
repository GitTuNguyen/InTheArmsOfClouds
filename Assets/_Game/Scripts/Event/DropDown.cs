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
    Events _eventBlock;

    public void _DropDown(int eventBlock)
    {
        
        switch (eventBlock) 
        {
            case 0:
                _eventBlock = Events.SEA;
                title.text = "SEA";
                eventDes.text = seaSO.EventDescription;
                optionList = seaSO.Options;
                Debug.LogFormat("event of sea block has {0} options", optionList.Count);
                int index = 0;
                foreach (TextMeshProUGUI optionDes in optionDesList)
                {
                    Transform optionButton = optionDes.transform.parent;
                    if (index < optionList.Count)
                    {
                        optionButton.gameObject.SetActive(true);
                        optionDes.text = optionList[index].OptionDescription;
                        optionButton.GetComponent<OptionHandle>().OptionData = optionList[index];
                        Debug.LogFormat("optionButton.GetComponent<OptionHandle>().OptionData.OptionDescription: {0}", optionButton.GetComponent<OptionHandle>().OptionData.OptionDescription);
                        ++index;
                    }
                    else
                    {

                        optionButton.gameObject.SetActive(false);
                    }
                    Debug.LogFormat("index: {0}", index);
                }    
                break;
            case 1:
                _eventBlock = Events.WOOD;
                title.text = "WOOD";
                eventDes.text = woodSO.EventDescription;
                optionList = woodSO.Options;
                Debug.LogFormat("event of wood block has {0} options", optionList.Count);
                /*index = 0;
                foreach (TextMeshProUGUI optionDes in optionDesList)
                {
                    Transform optionButton = optionDes.transform.parent;
                    if (index < optionList.Count)
                    {
                        optionButton.gameObject.SetActive(true);
                        optionDes.text = optionList[index].OptionDescription;
                        ++index;
                    }
                    else
                    {
                        
                        optionButton.gameObject.SetActive(false);
                    }
                }*/
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
