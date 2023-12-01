using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    Button button;
    private void Start() {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    public void OnButtonClick()
    {
        SFXManager.Instance?.PlaySound("ButtonClick");
    }

    public void OnPointerEnter(PointerEventData eventData){
        SFXManager.Instance?.PlaySound("ButtonHover");
    }
}
