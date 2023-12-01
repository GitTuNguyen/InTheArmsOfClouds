using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using System;
using JetBrains.Annotations;
using UnityEngine.Rendering;

public class InventoryItemUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public InventoryUIManager inventoryUIManager;
    public int slotID;
    //Call info popup    
    public GameObject infoPopupPrefabs;
    public Transform infoPopupPos;
    private ItemInfoUI itemInfoUI;
    public float showInfoPopupTimeDelay = 0.25f;
    private InventoryItemData itemData;

    //Item data
    public Image itemImage;
    public TextMeshProUGUI itemQuantity;

    //Remove Item
    public GameObject removeButton;
    public Animator itemUIAnimator;
    public bool isRemoveSelecting = false;
    
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("Item UI down");
        StartCoroutine(ShowInfo());
    }
    
    public void OnPointerUp(PointerEventData eventData){
        Debug.Log("Item UI Up");
        StopAllCoroutines();
        if (itemData != null && itemInfoUI == null && !isRemoveSelecting)
        {
            Debug.Log("Using Item UI");
            ActionPhaseUIManager.Instance.OnItemClick(slotID);
        }else if (isRemoveSelecting)
        {
            Debug.Log("OnPointerUp cancel RemoveItem");
            inventoryUIManager.CancelRemoveItem();
        }
        HideInfo();
    }

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("Item UI Clicked");
        
    }

    IEnumerator ShowInfo()
    {
        yield return new WaitForSeconds(showInfoPopupTimeDelay);
        if (itemInfoUI == null && itemData != null)
        {
            GameObject infoPoup = Instantiate(infoPopupPrefabs, infoPopupPos);
            itemInfoUI = infoPoup.GetComponent<ItemInfoUI>();
            itemInfoUI.SetItemInfoData(itemData);
        }        
    }

    private void HideInfo()
    {
        if (itemInfoUI != null)
        {
            Destroy(itemInfoUI.gameObject);
            itemInfoUI = null;
            StartRemoveSeletion();
        }
    }
    
    public void SetItemData(InventorySlot inventorySlotData, int index = -1)
    {
        slotID = index == -1 ? slotID : index;
        itemData = inventorySlotData.ItemData;
        itemImage.sprite = inventorySlotData.ItemData.icon;
        itemQuantity.text = inventorySlotData.StackSize.ToString();
        itemImage.enabled = true;
        itemQuantity.enabled = true;
    }

    //Remove Item
    public void RemoveItemData()
    {
        Debug.Log("Item remove - UI");
        InventoryHolder.Instance.RemoveItemAtIndex(slotID);
        ClearSlotUI();
    }

    public void ClearSlotUI()
    {
        itemData = null;
        itemImage.sprite = null;
        itemQuantity.text = 0.ToString();
        itemImage.enabled = false;
        itemQuantity.enabled = false;
    }
    public void StartRemoveSeletion()
    {
        Debug.Log("start remove item");
        inventoryUIManager.currentSlotRemoveSelected = slotID;
        removeButton.SetActive(true);
        isRemoveSelecting = true;
        StartRemoveSeletionAnimation();
    }
    public void CancelRemoveItem()
    {
        Debug.Log("Cancel remove item");
        removeButton.SetActive(false);
        StopRemoveSeletionAnimation();
        isRemoveSelecting = false;
    }
    public void StartRemoveSeletionAnimation()
    {
        itemUIAnimator.enabled = true;
        itemUIAnimator.SetTrigger("RemoveSelection");
    }
    public void StopRemoveSeletionAnimation()
    {
        itemUIAnimator.enabled = false;
        itemImage.transform.rotation = Quaternion.identity;
    }

    public void OnRemoveButtonPressed()
    {
        RemoveItemData();
        StopRemoveSeletionAnimation();
        removeButton.SetActive(false);
    }

    
}
