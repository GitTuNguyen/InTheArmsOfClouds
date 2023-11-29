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
    private Vector3 defaulPos;
    public TMPro.TextMeshProUGUI buttonTMP;
    public float offSet = -10f;
    public float pointerEnterScale = 1.2f;
    private void Start() {
        if (!String.IsNullOrEmpty(defaultText))
        {
            buttonTMP.text = defaultText;
        }
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (String.IsNullOrEmpty(defaultText))
        {
            defaultText = buttonTMP.text;
        }
        if (defaulPos == Vector3.zero)
        {
            defaulPos = transform.position;
        }
        buttonTMP.text = "> " + defaultText;
        transform.position = new Vector3(transform.position.x + offSet, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(pointerEnterScale, pointerEnterScale, pointerEnterScale);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonTMP.text = defaultText;
        transform.position = defaulPos;
        transform.localScale = Vector3.one;
    }
}
