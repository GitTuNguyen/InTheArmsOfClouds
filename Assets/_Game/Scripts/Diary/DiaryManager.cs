using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{

    public List<ConsequenceData> grassConsequenceList;
    public List<ConsequenceData> seaConsequenceList;
    public List<ConsequenceData> desertConsequenceList;
    public List<ConsequenceData> woodConsequenceList;

    public void AddConsequence(ConsequenceData consequenceData, BlockType blockType){
        switch (blockType)
        {
            case BlockType.Grass:
            /*if(grassConsequenceList == null){
                grassConsequenceList.Add(consequenceData);
            }else if (IsConsequenceExist(...){
                    grassConsequenceList.Add(consequenceData);
                }
            }
            
            */
                if(IsConsequenceExist(consequenceData, BlockType.Grass)){
                    grassConsequenceList.Add(consequenceData);
                } else{
                    Debug.Log(" ");
                }
                break;
            
            case BlockType.Desert:
            case BlockType.Sea:
            case BlockType.Wood:
                break;
        }
    }

    public bool IsConsequenceExist(ConsequenceData consequenceData, BlockType blockType){
        switch (blockType)
        {
            case BlockType.Grass:
                //consequenceData.consequenceCode;
                break;
            
            case BlockType.Desert:
            case BlockType.Sea:
            case BlockType.Wood:
                break;
        }
        return true;
    }
}
