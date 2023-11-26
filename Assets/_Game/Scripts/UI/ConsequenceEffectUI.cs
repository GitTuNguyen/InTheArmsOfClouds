using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class ConsequenceEffectUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI effectQuantityTF;
    public TMPro.TextMeshProUGUI effectStatTF;

    public void SetConsequenseEffect(int stat, string name)
    {
        if (stat > 0)
        {
            effectQuantityTF.color = Color.green;
            effectQuantityTF.text = "+ " + stat.ToString() + " ";
        } else {
            effectQuantityTF.color = Color.red;
            effectQuantityTF.text = "- " + Math.Abs(stat).ToString() + " ";
        }
        effectStatTF.text = name;
    }
}
