using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMaterialUI : MonoBehaviour
{
    public Image materialImage;
    public TMPro.TextMeshProUGUI quarityText;

    public void SetupMaterial(Sprite sprite, int currentQuarity, int requiredQuarity)
    {
        materialImage.sprite = sprite;
        if (currentQuarity < requiredQuarity)
        {
            quarityText.color = Color.red;
        } else {
            quarityText.color = Color.green;
        }
        quarityText.text = currentQuarity.ToString() + " / " + requiredQuarity.ToString();
    }
}
