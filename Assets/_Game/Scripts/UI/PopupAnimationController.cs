using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PopupAnimationController : MonoBehaviour
{
    public float minScale = 0.25f;
    public float maxScalse = 1f;
    public float animationDurationTime = 0.15f;
    public float animationTime;
    public bool needAnimation = true;

    // Start is called before the first frame update
    private void OnEnable() 
    {
        if (needAnimation)
        {            
            OpenPopup();
        }
    }

    public void OpenPopup()
    {
        transform.localScale = new Vector2(minScale, minScale);
        StopAllCoroutines();
        Debug.Log("OpenPopup");
        StartCoroutine(PopupOpenAnimation());
    }

    public void ClosePopup()
    {
        Debug.Log("Close Popup");
        if (needAnimation)
        {            
            transform.localScale = new Vector2(maxScalse, maxScalse);
            StopAllCoroutines();
            StartCoroutine(PopupCloseAnimation());
        } else {
            Destroy(gameObject);
        }
        ActionPhaseUIManager.Instance.panel.SetActive(false);
    }

    IEnumerator PopupOpenAnimation()
    {        
        Debug.Log("animationTime " + animationTime);
        while (animationTime < animationDurationTime)
        {
            animationTime += Time.deltaTime;
            float currentScalse = Mathf.Lerp(minScale, maxScalse, animationTime / animationDurationTime);
            transform.localScale = new Vector2(currentScalse, currentScalse);
            yield return null;
        }
        animationTime = 0;
    }

    IEnumerator PopupCloseAnimation()
    {
        while (animationTime < animationDurationTime)
        {
            animationTime += Time.deltaTime;
            float currentScalse = Mathf.Lerp(maxScalse, minScale, animationTime / animationDurationTime);
            transform.localScale = new Vector2(currentScalse, currentScalse);
            yield return null;
        }
        animationTime = 0;
        Destroy(gameObject);
    }
}
