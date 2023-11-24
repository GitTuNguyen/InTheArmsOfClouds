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

    private void OnEnable()
    {
        EventManager.SelectBlockOnTheMap += UpdateNumberOfStep;   
    }

    private void OnDisable()
    {
        EventManager.SelectBlockOnTheMap -= UpdateNumberOfStep;
    }

    public void EnableUICanvas(int number)
    {
        uiCanvas.SetActive(true);
        numberOfStep.text = number.ToString();
    }

    public void DisableUICanvas()
    {
        uiCanvas.SetActive(false);
    }

    public void UpdateNumberOfStep(int number)
    {
        numberOfStep.text = number.ToString();
    }
}
