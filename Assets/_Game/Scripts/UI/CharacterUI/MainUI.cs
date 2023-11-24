using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    private GameObject mainUI;

    [SerializeField] 
    private GameObject diceUI;

    [SerializeField]
    private Dice dice;

    [SerializeField]
    private PlayerController player;
    // Start is called before the first frame update

    public void ShowRollDice()
    {
        mainUI.SetActive(false);
        diceUI.SetActive(true);
        int number = player.numberDice;
        StartCoroutine(WaitingToShowDice(2,number));
        Debug.Log(number);
    }

    private void ShowMainUI()
    {
        mainUI.SetActive(true);
        diceUI.SetActive(false);
        EventManager.Instance.SwitchStateToSelectPath?.Invoke();
    }

    IEnumerator WaitingToShowDice(float time,int number)
    {
        yield return new WaitForSeconds(time);

        dice.RollDice(number);

        yield return new WaitForSeconds(1);

        ShowMainUI();
    
        
    }
}
