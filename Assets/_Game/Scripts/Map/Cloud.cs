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

    

    SpriteRenderer m_SpriteRenderer;

    void Start() 
    {
        isPredition = false;
        isHightLight = false;
        originMaterial = GetComponent<Renderer>().material;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click cloud");
    }

    public void ActivePreHightLight()
    {
        isPredition = true;
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.gray;
        }
        else
        {
            GetComponent<Renderer>().material = preMaterial;
        }
    }

    public void DeActivePreHighLight()
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material = originMaterial;
        }
        
        isPredition = false;
    }

    private void ActiveHightLight()
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material = hightlighMaterial;
        }
        isPredition = false;
        isHightLight = true;
    }

    private void DeactiveHightLight()
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.grey;
        }
        else
        {
            GetComponent<Renderer>().material = preMaterial;
        }

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
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material = originMaterial;
        }      
        isPredition = false;
        isHightLight = false;
    }
}

