using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject highLight;

    [SerializeField]
    private GameObject predition;

    private bool isHighLight;
    private bool isPredition;

    public bool IsPredition
    {
        get { return isPredition; }
        set { isPredition = value; }
    }
    public bool IsHighLight
    {
        get { return isHighLight; }
        set { isHighLight = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isHighLight = false;
        isPredition = false;
    }


    public void ActiveHightLighBlock()
    {
        highLight.SetActive(true);
        DeactivePreditionBlock();
        isHighLight = true;
    }

    public void DeactiveHightLightBlock()
    {
        highLight.SetActive(false);
        isHighLight = false;
    }

    public void ActivePreditionBlock()
    {
        isPredition = true;
        predition.SetActive(true);
    }

    public void DeactivePreditionBlock()
    {
        isPredition = false;
        predition.SetActive(false);
    }

    public void ResetBlock()
    {
        isPredition = false;
        predition.SetActive(false);
        isHighLight= false;
        highLight.SetActive(false);
    }
}
