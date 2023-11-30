using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using System;
using JetBrains.Annotations;

public class InventoryItemUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerMoveHandler, IPointerExitHandler, IPointerEnterHandler
{
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
    
    //Drag
    bool isPointerEnter = true;
    bool isPointerDown;
    public GameObject dragItemPrefabs;
    [SerializeField] private GameObject dragItem;

    private void Update() {
        if (dragItem != null)
        {
            dragItem.transform.position = Input.mousePosition;
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        isPointerDown = true;
        StartCoroutine(ShowInfo());
    }
    
    public void OnPointerUp(PointerEventData eventData){
        isPointerDown = false;
        HideInfo();
        if (itemData != null)
        {
            if (isPointerEnter)
            {
                ItemReturn();
            } else {
                InventoryHolder.Instance.RemoveItemAtIndex(slotID);
            }
        }
        
    }

    public void OnPointerClick(PointerEventData eventData){

    }
    public void OnPointerMove(PointerEventData eventData){
        if (isPointerDown && dragItem == null && itemData != null)
        {
            Debug.Log("Pointer move");
            HideInfo();
            dragItem = Instantiate(dragItemPrefabs, this.transform);
            Image dragItemImage = dragItem.GetComponent<Image>();
            if (dragItemImage != null)
            {
                dragItemImage.sprite = itemImage.sprite;                
                itemImage.enabled = false;
                itemQuantity.enabled = false;
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        isPointerEnter = true;
    }
    public void OnPointerExit(PointerEventData eventData){
        isPointerEnter = false;
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
        StopAllCoroutines();
        if (itemInfoUI != null)
        {
            Destroy(itemInfoUI.gameObject);
            itemInfoUI = null;
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

    private void ItemReturn()
    {
        Debug.Log("Item return");
        //Destroy(dragItem);
        dragItem = null;
        itemImage.enabled = true;
        itemQuantity.enabled = true;
    }
    public void RemoveItemData()
    {
        itemImage.sprite = null;
        itemQuantity.text = 0.ToString();
        itemImage.enabled = false;
        itemQuantity.enabled = false;
    }
}
