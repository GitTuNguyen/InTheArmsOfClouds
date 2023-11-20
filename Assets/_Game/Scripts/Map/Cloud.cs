using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cloud : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Material preMaterial;

    [SerializeField]
    private Material hightlighMaterial;

    private Material originMaterial;

    private bool isPredition;
    private bool isHightLight;

    void Start() 
    {
        isPredition = false;
        isHightLight = false;
        originMaterial = GetComponent<Renderer>().material;
        //GetComponent<Renderer>().material =  preMaterial;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click cloud");
    }

    public void ActivePreHightLight()
    {
        isPredition = true;
        GetComponent<Renderer>().material = preMaterial;
    }

    public void DeActivePreHighLight()
    {
        GetComponent<Renderer>().material = originMaterial;
        isPredition = false;
    }

    private void ActiveHightLight()
    {
        GetComponent<Renderer>().material = hightlighMaterial;
        isPredition = false;
        isHightLight = true;
    }

    private void DeactiveHightLight()
    {
        GetComponent<Renderer>().material = preMaterial;
        isPredition = true;
        isHightLight = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isPredition)
        {
            ActiveHightLight();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isHightLight)
        {
            DeactiveHightLight();
        }
    }

    public void ResetCloud()
    {
        GetComponent<Renderer>().material = originMaterial;
        isPredition = false;
        isHightLight = false;
    }
}

