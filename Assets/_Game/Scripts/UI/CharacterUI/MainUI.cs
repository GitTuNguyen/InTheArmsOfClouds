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

    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private Camera cameraUI;
    // Start is called before the first frame update

    public void Start()
    {
        //Cursor.visible = false;
        arrow.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.EndOfTurnUseItem += DeactiveCurrsor;
    }

    private void OnDisable()
    {
        EventManager.EndOfTurnUseItem -= DeactiveCurrsor;
    }

    public void Update()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 pos = cameraUI.ScreenToWorldPoint(mouse);

        arrow.transform.position = new Vector3(pos.x, pos.y, 0);
    }

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
        EventManager.SwitchStateToSelectPath?.Invoke();
    }

    IEnumerator WaitingToShowDice(float time,int number)
    {
        yield return new WaitForSeconds(time);

        dice.RollDice(number);

        yield return new WaitForSeconds(1);

        ShowMainUI();
     
    }

    public void UseAmuletItem()
    {
        Cursor.visible = false;
        arrow.SetActive(true);
        EventManager.UseAmuletItem?.Invoke();
    }

    public void DeactiveCurrsor()
    {
        Cursor.visible = true;

        arrow.SetActive(false);
    }
}
