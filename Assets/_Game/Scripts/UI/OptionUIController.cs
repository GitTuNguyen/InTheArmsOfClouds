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

    public void SelectionOption()
    {
        Debug.Log("Select event option");
    }
}
