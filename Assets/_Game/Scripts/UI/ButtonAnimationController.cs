using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class ButtonAnimationController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string defaultText;
    //private Vector3 defaulPos = Vector3.zero;
    private float defaultFontSize;
    public TMPro.TextMeshProUGUI buttonTMP;
    public float offSet = -10f;
    public float pointerEnterScale = 1.2f;
    private void OnEnable() {
        if (!String.IsNullOrEmpty(defaultText))
        {
            Debug.Log("Set button text to default");
            buttonTMP.text = defaultText;
        }
        // if (defaulPos != Vector3.zero)
        // {
        //     transform.position = defaulPos;
        // }
        if (defaultFontSize == 0)
        {
            defaultFontSize = buttonTMP.fontSize;
        }
    } 
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (String.IsNullOrEmpty(defaultText))
        {
            defaultText = buttonTMP.text;
        }
        // if (defaulPos == Vector3.zero)
        // {
        //     defaulPos = transform.position;
        // }
        buttonTMP.text = "> " + defaultText;
        //transform.position = new Vector3(transform.position.x + offSet, transform.position.y, transform.position.z);
        buttonTMP.fontSize = defaultFontSize * pointerEnterScale;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonTMP.text = defaultText;
        //transform.position = defaulPos;
        buttonTMP.fontSize = defaultFontSize;
    }
}
