using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject uiCanvas;

    [SerializeField]
    private TextMeshProUGUI numberOfStep;
    // Start is called before the first frame update

    private void OnEnable()
    {
        EventManager.Instance.SelectBlockOnTheMap += UpdateNumberOfStep;   
    }

    private void OnDisable()
    {
        EventManager.Instance.SelectBlockOnTheMap -= UpdateNumberOfStep;
    }

    public void EnableUICanvas(int number)
    {
        uiCanvas.active = true;
        numberOfStep.text = number.ToString();
    }

    public void DisableUICanvas()
    {
        uiCanvas.active = false;
    }

    public void UpdateNumberOfStep(int number)
    {
        numberOfStep.text = number.ToString();
    }
}
