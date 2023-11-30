using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    public static DiaryManager Instance;

    [Serializable]public struct DiaryClass
    {
        public string className;
        public List<ConsequenceData> consequenceList;
        
        public DiaryClass(string name)
        {
            className = name;
            consequenceList = new List<ConsequenceData>();
        }
    }
    // public List<ConsequenceData> grassConsequenceList = new List<ConsequenceData>();
    // public List<ConsequenceData> seaConsequenceList = new List<ConsequenceData>();
    // public List<ConsequenceData> desertConsequenceList = new List<ConsequenceData>();
    // public List<ConsequenceData> woodConsequenceList = new List<ConsequenceData>();
    [SerializeField]private DiaryClass grass;
    [SerializeField]private DiaryClass wood;
    [SerializeField]private DiaryClass sea;
    [SerializeField]private DiaryClass desert;

    public List<DiaryClass> diaryContainer;

    private void Start() {
        if (Instance == null)
        {
            Instance = this;
        }
        grass = new DiaryClass ("Grass");
        wood = new DiaryClass ("Wood");
        sea = new DiaryClass ("Sea");
        desert = new DiaryClass ("Desert");

        diaryContainer.Add(grass);
        diaryContainer.Add(wood);
        diaryContainer.Add(sea);
        diaryContainer.Add(desert);
    }

    public void AddConsequence(ConsequenceData consequenceData, BlockType blockType){
        switch (blockType)
        {
            case BlockType.Grass:            
                AddConsequenceList(consequenceData, grass.consequenceList);
                break;
            
            case BlockType.Sea:
                AddConsequenceList(consequenceData, sea.consequenceList);
                break;
            
            case BlockType.Desert:
                AddConsequenceList(consequenceData,  desert.consequenceList);
                break;

            case BlockType.Wood:
                AddConsequenceList(consequenceData, wood.consequenceList);
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

    public List<ConsequenceData> GetConsequenceDataByClassName(string diatyClassname)
    {
        foreach (DiaryClass diaryClass in diaryContainer)
        {
            if (diaryClass.className == diatyClassname)
            {
                return diaryClass.consequenceList;
            }
        }
        return null;
    }

    public void ClearDiaryData()
    {
        grass.consequenceList.Clear();
        wood.consequenceList.Clear();
        sea.consequenceList.Clear();
        desert.consequenceList.Clear();
    }
}
