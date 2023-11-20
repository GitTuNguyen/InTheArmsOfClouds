using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceDataSO", menuName = "Event System/Consequence")]

public class ConsequenceData : ScriptableObject
{
    public int consequenceId;
    public string consequenceDescription;
    public Sprite artwork;
}
