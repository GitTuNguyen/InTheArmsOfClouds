using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvenDataSo", menuName = "Event System/Event")]

public class EventData : ScriptableObject
{
    [SerializeField]
    private Events eventBlock;
    public Events EventBlock
    {
        get { return eventBlock; }
    }    

    [SerializeField]
    private int eventId;

    [SerializeField]
    private string eventDescription;
    public string EventDescription
    {
        get { return eventDescription; }
        set { eventDescription = value; }
    }

    [SerializeField]
    private List<OptionData> options;
    public List<OptionData> Options
    { 
        get { return options; } 
        set {  options = value; } 
    }

}
