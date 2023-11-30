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
    private string optionDesc; 
    public string OptionDesc
    {
        get { return optionDesc; }
        set { optionDesc = value; }
    }

    [SerializeField]
    private List<ConsequenceData> consequences;
    public List<ConsequenceData> Consequences
    {
        get { return consequences; }
        set { consequences = value; }
    }

    [SerializeField]
    private TriggerCondition triggerCondition;

    public bool TriggerCondition()
    {
        if (triggerCondition == null)
        {
            Debug.LogFormat("OptionData_{0} doesn't have condition", OptionId);
            return false;
        }
        if (triggerCondition.CheckCondition() == false)
        {
            Debug.LogFormat("OptionData_{0} has condition that is false", OptionId);
            return false;
        }
        Debug.LogFormat("OptionData_{0} has condition that is true", OptionId);
        return true;
    }

    public ConsequenceData TriggerOption()
    {
        if (TriggerCondition() == false)
        {
            int totalWeigt = TotalWeight();
            int randomValue = Random.Range(0, totalWeigt);
            int cumulativeWeight = 0;
            foreach (ConsequenceData consequence in consequences)
            {
                cumulativeWeight += consequence.weight;
                if (randomValue < cumulativeWeight)
                {
                    consequence.DeployEffects();    //temporary deploy effect in here
                    return consequence;
                }
            }
        }
        Debug.LogFormat("Get type E Consequence of OptionData_{0}", OptionId);
        return GetEConsequence();
    }

    public int TotalWeight()
    {
        int totalWeight = 0;
        foreach (ConsequenceData consequence in consequences)
        {
            totalWeight += consequence.weight;
        }
        return totalWeight;
    }

    public ConsequenceData GetEConsequence()
    {
        foreach (ConsequenceData consequence in consequences)
        {
            if (consequence.weight != 0) //tu hard code
            {
                consequence.DeployEffects();
                Debug.LogFormat("Get type E ConsequenceData_{0} having weight: {1}", consequence.consequenceCode, consequence.weight);
                return consequence;
            }    
        }
        return consequences;
    }
}
