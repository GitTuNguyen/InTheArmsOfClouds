using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OptionUIController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI optionText;
    private OptionData currentOption;
    public void SetupOption(OptionData optionData)
    {
        currentOption = optionData;
        optionText.text = optionData.OptionDesc;
    }

    public void SelectOption()
    {
        if (currentOption != null)
        {
            Debug.Log("Option selected");
            GameManager.Instance.CurrentConsequnce = currentOption.TriggerOption();
            ActionPhaseUIManager.Instance?.StartConsequencesLoading();
        } else {
            Debug.LogError("No option was set");
        }        
    }
}
