using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
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
}
