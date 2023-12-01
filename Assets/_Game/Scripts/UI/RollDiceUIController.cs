using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RollDiceUIController : MonoBehaviour
{
    [System.Serializable] public struct Dice 
    {
        public int value;
        public Sprite image;
    }
    public List<Dice> diceTemplateList;
    public Image diceImage;
    public float rollDiceDurationTime = 2f;
    public int resultDice = 1;
    private Animator animator;    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartRollDice(GameManager.Instance.currentDiceNumber);
    }

    public void StartRollDice(int value)
    {
        Debug.Log("Start Roll Dice");
        StartCoroutine(ShowRollDiceResult(value));
    }
    IEnumerator ShowRollDiceResult(int value)
    {
        SFXManager.Instance?.PlaySound("RollDice");
        yield return new WaitForSeconds(rollDiceDurationTime);
        animator.enabled = false;
        SFXManager.Instance?.StopSound("RollDice");
        foreach (Dice dice in diceTemplateList)
        {
            if (dice.value == value)
            {
                diceImage.sprite = dice.image;
                break;
            }
        }
        Debug.Log("Dice complete");
        ActionPhaseUIManager.Instance.TogglePanel();
        ActionPhaseUIManager.Instance.TogglePanel(true);        
        EventManager.SwitchStateToSelectPath?.Invoke();
        
    }
    
}
