using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    private GameObject highLight;

    [SerializeField]
    private GameObject predition;

    private bool isHighLight;
    private bool isPredition;

    [SerializeField]
    private BlockType blockType;

    [SerializeField]
    private Cloud cloud;

    private bool isSelected;

    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    private bool isHasCloud;

    public bool IsHasCloud
    {
        get { return isHasCloud; }
        set {  isHasCloud = value; }
    }

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

    // ninh.nghiemthanh: Trigger event
    public EventData eventDataSO;

    public void TriggerEvent()
    {
        ActionPhaseUIManager.Instance.TriggerEvent(eventDataSO);
    }

    // Start is called before the first frame update
    void Start()
    {
        isHighLight = false;
        isPredition = false;
        isHasCloud = true;
        isSelected = false;
    }


    public void ActiveHightLighBlock()
    {
        if(!isSelected)
        {
            highLight.SetActive(true);
            DeactivePreditionBlock();
            isHighLight = true;

        }

    }

    public void DeactiveHightLightBlock()
    {
        highLight.SetActive(false);
        isHighLight = false;
    }

    public void ActivePreditionBlock()
    {
        if(!isSelected)
        {
            isPredition = true;
            predition.SetActive(true);
            if (isHasCloud)
            {
                if (cloud != null)
                {
                    cloud.ActivePreHightLight();
                }
            }
        }

    }

    public void DeactivePreditionBlock()
    {
        isPredition = false;
        predition.SetActive(false);
    }

    public void ActivePreditionCouldBlock()
    {
        if (isHasCloud)
        {
            if (cloud != null)
            {
                cloud.ActivePreHightLight();
            }
        }
    }

    public void DeactivePreditionCouldBlock()
    {
        if (isHasCloud)
        {
            if (cloud != null)
            {
                cloud.DeActivePreHighLight();
            }
        }
    }

    public void ResetBlock()
    {
        isPredition = false;
        predition.SetActive(false);
        isHighLight= false;
        highLight.SetActive(false);
        if (cloud != null)
        {
            cloud.ResetCloud();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isPredition)
        {
            ActiveHightLighBlock();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isHighLight)
        {
            DeactiveHightLightBlock();
            ActivePreditionBlock();
        }
    }

    public bool CheckCloudOfBlock()
    {
        if(cloud == null) return false;
        if(cloud.gameObject.activeInHierarchy == false) return false;
        return true;
    }

    public void RemoveCloudOfBlock()
    {
        if(cloud != null)
        {
            cloud.gameObject.SetActive(false);
        }
    }
}
