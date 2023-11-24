using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalUI : MonoBehaviour
{
    [SerializeField]
    private Slider hungerBar;

    [SerializeField]
    private Slider thirstBar;

    [SerializeField]
    private Slider reproductiveBar;

    [SerializeField]
    private TextMeshProUGUI age;

    [SerializeField]
    private TextMeshProUGUI status;
    // Start is called before the first frame update
    void Start()
    {
        ResetAnimalUI();
    }

    private void ResetAnimalUI()
    {
        thirstBar.value = 0;
        hungerBar.value = 0;
        reproductiveBar.value = 0;
        age.text = "0";
        status.text = "Live";
    }

    public void SetAnimalUI(float hunger, float thirst, float reproductive)
    {
        if (reproductive == 0)
        {
            reproductiveBar.gameObject.SetActive(false);
        }
        else
        {
            reproductiveBar.gameObject.SetActive(true);

            reproductiveBar.value = reproductive;
        }

        thirstBar.value = thirst;
        hungerBar.value = hunger;
    }
}
