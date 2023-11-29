using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    public List<ConsequenceData> grassConsequenceList = new List<ConsequenceData>();
    public List<ConsequenceData> seaConsequenceList = new List<ConsequenceData>();
    public List<ConsequenceData> desertConsequenceList = new List<ConsequenceData>();
    public List<ConsequenceData> woodConsequenceList = new List<ConsequenceData>();

    public void AddConsequence(ConsequenceData consequenceData, BlockType blockType){
        switch (blockType)
        {
            case BlockType.Grass:            
                AddConsequenceList(consequenceData, grassConsequenceList);
                break;
            
            case BlockType.Sea:
                AddConsequenceList(consequenceData, seaConsequenceList);
                break;
            
            case BlockType.Desert:
                AddConsequenceList(consequenceData,  desertConsequenceList);
                break;

            case BlockType.Wood:
                AddConsequenceList(consequenceData, woodConsequenceList);
                break;
        }
    }
    public void AddConsequenceList(ConsequenceData consequenceData, List<ConsequenceData> consequenceList){
        if(!consequenceList.Any(consequence => consequence.consequenceCode == consequenceData.consequenceCode)){
            consequenceList.Add(consequenceData);
            Debug.Log($"Consequence {consequenceData.consequenceCode} added to the list");
        } else{
            Debug.Log($"Consequence {consequenceData.consequenceCode} is exist or don't have in list");
        }
    }
}
