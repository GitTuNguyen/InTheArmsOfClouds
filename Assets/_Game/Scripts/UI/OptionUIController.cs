using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OptionUIController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI optionText;
    private OptionData currentOption;
    public void SetupOption(OptionData optionData, int index)
    {
        currentOption = optionData;
        optionText.text = index.ToString() + ". " + optionData.OptionDesc;
    }

    public void SelectOption()
    {
        if (currentOption != null)
        {
            Debug.Log("Option selected");
            GameEventSystem.Instance.CurrentConsequnce = currentOption.GetConsequence();
            GameEventSystem.Instance.TriggerEvent();
        } else {
            Debug.LogError("No option was set");
        }
    }


}
