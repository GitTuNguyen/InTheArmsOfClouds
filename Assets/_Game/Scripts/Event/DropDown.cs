using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

// This script just use in Ninh's demo
public class DropDown : MonoBehaviour
{
    public TextMeshProUGUI title;
    public EventData seaSO;
    public EventData woodSO;
    public EventData desertSO;
    public EventData grassSO;
    public TextMeshProUGUI eventDesc;
    public List<TextMeshProUGUI> optionDescList;
    List<OptionData> optionList;
    BlockType _eventBlock;

    void DeployEvent()
    {
        int index = 0;
        foreach (TextMeshProUGUI optionDesc in optionDescList)
        {
            Transform optionButton = optionDesc.transform.parent;
            if (index < optionList.Count)
            {
                optionButton.gameObject.SetActive(true);
                optionDesc.text = optionList[index].OptionDesc;
                optionButton.GetComponent<OptionHandle>().OptionData = optionList[index];
                Debug.LogFormat("optionButton.GetComponent<OptionHandle>().OptionData.OptionDescription: {0}", optionButton.GetComponent<OptionHandle>().OptionData.OptionDesc);
                ++index;
            }
            else
            {

                optionButton.gameObject.SetActive(false);
            }
        }
    }    

    public void _DropDown(int eventBlock)
    {
        
        switch (eventBlock) 
        {
            case 0:
                _eventBlock = BlockType.Sea;
                title.text = "SEA";
                eventDesc.text = seaSO.EventDesc;
                optionList = seaSO.Options;
                Debug.LogFormat("event of sea block has {0} options", optionList.Count);
                DeployEvent();   
                break;
            case 1:
                _eventBlock = BlockType.Wood;
                title.text = "WOOD";
                eventDesc.text = woodSO.EventDesc;
                optionList = woodSO.Options;
                Debug.LogFormat("event of wood block has {0} options", optionList.Count);
                DeployEvent();
                break;
            case 2:
                _eventBlock = BlockType.Desert;
                title.text = "DESERT";
                eventDesc.text = desertSO.EventDesc;
                optionList = desertSO.Options;
                Debug.LogFormat("event of desert block has {0} options", optionList.Count);
                DeployEvent();
                break;
            case 3:
                _eventBlock = BlockType.Grass;
                title.text = "GRASS";
                eventDesc.text = grassSO.EventDesc;
                optionList = grassSO.Options;
                Debug.LogFormat("event of grass block has {0} options", optionList.Count);
                DeployEvent();
                break;
        }
    }
}
