using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionDataSO", menuName = "Event System/Option")]
public class OptionData : ScriptableObject
{
    [SerializeField]
    private int optionId;
    public int OptionId
    {
        get { return optionId; }
        set { optionId = value; }
    }    

    [SerializeField]
    private string optionDescription; 
    public string OptionDescription
    {
        get { return optionDescription; }
        set { optionDescription = value; }
    }

    [SerializeField] 
    private object optionObject;

    [SerializeField]
    private List<ScriptableObject> consequences;
}
