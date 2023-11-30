using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem Instance;
    //Consequence 
    [SerializeField]private ConsequenceData  currentConsequnce;
    public ConsequenceData  CurrentConsequnce 
    {
        get => currentConsequnce; 
        set 
        {
            if (currentConsequnce == null)
            {
                currentConsequnce = value;
            }
        }
    }

    public EventData grassEvent;
    public EventData desertEvent;    
    public EventData seaEvent;
    public EventData woodEvent;
    
    private void Start() {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void ClearConsequenceData()
    {
        currentConsequnce = null;
    }

    public void TriggerEvent(BlockType blockType)
    {
        switch (blockType)
        {
            case BlockType.Grass:
                ActionPhaseUIManager.Instance?.TriggerEvent(grassEvent);
                return;
            case BlockType.Desert:
                ActionPhaseUIManager.Instance?.TriggerEvent(desertEvent);
                return;
            case BlockType.Sea:
                ActionPhaseUIManager.Instance?.TriggerEvent(seaEvent);
                return;
            case BlockType.Wood:
                ActionPhaseUIManager.Instance?.TriggerEvent(woodEvent);
                return;
            case BlockType.SpaceShip:
                InventoryHolder.Instance?.InventorySystem.AddSpaceShip();
                ActionPhaseUIManager.Instance?.OpenFindSpaceshipPopup();
                return;
            default:
            return;
        }
    }

    public void TriggerEvent()
    {
        if (currentConsequnce != null)
        {
            ActionPhaseUIManager.Instance.StartConsequencesLoading();
        }
    }
}
