using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggerConditionSO", menuName = "Event System/Trigger Condition")]
public class TriggerCondition : ScriptableObject
{
    public int healthCond;
    public int luckCond;
    public int sanityCond;
    public int meatCond;
    public int logCond;
    public int cropCond;
    public int gemCond;
    public int seashellCond;
    public int magicScrollCond;

    public bool CheckCondition()
    {
        // Todo: Check condition - wip
        if (healthCond > 0)
        {
            Debug.LogFormat("Check condition health >= {0}", healthCond);
            return false;
        }
        if (luckCond > 0)
        {
            Debug.LogFormat("Check condition luck >= {0}", luckCond);
            return false;
        }
        if (sanityCond > 0)
        {
            Debug.LogFormat("Check condition sanity >= {0}", sanityCond);
            return false;
        }
        if (meatCond > 0)
        {
            Debug.LogFormat("Check condition meat >= {0}", meatCond);
            return false;
        }
        if (logCond > 0)
        {
            Debug.LogFormat("Check condition log >= {0}", logCond);
            return false;
        }
        if (cropCond > 0)
        {
            Debug.LogFormat("Check condition crop >= {0}", cropCond);
            return false;
        }
        if (gemCond > 0)
        {
            Debug.LogFormat("Check condition gem >= {0}", gemCond);
            return false;
        }
        if (seashellCond > 0)
        {
            Debug.LogFormat("Check condition seashell >= {0}", seashellCond);
            return false;
        }
        if (magicScrollCond > 0)
        {
            Debug.LogFormat("Check condition magicScroll >= {0}", magicScrollCond);
            return false;
        }
        return true;
    }
}
