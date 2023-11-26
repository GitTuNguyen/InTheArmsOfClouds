using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvenDataSo", menuName = "Event System/Event")]

public class EventData : ScriptableObject
{
    [SerializeField]
    private BlockType eventBlock;
    public BlockType EventBlock
    {
        get { return eventBlock; }
    }    

    [SerializeField]
    private int eventId;
    public int EventID
    {
        get { return eventId; }
        set { eventId = value; }
    }    

    [SerializeField] 
    private Sprite eventArtwork;
    public Sprite EventArtwork
    { 
        get { return eventArtwork; }
        set { eventArtwork = value; }
    }

    [SerializeField]
    private string eventDesc;
    public string EventDesc
    {
        get { return eventDesc; }
        set { eventDesc = value; }
    }

    [SerializeField]
    private List<OptionData> options;
    public List<OptionData> Options
    { 
        get { return options; } 
        set {  options = value; } 
    }

}
