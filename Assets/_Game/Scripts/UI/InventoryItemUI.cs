using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

public class InventoryItemUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Call info popup
    public GameObject infoPopupPrefabs;
    public Transform infoPopupPos;
    private ItemInfoUI itemInfoUI;
    public float showInfoPopupTimeDelay = 0.25f;
    //private InventoryItemData itemData = null;

    //Item data
    public GameObject itemImageObject;
    public Image itemImage;
    public GameObject itemQuantityObject;
    public TextMeshProUGUI itemQuantity;
    public void OnPointerDown(PointerEventData eventData){
        StartCoroutine(ShowInfo());
    }
    
    public void OnPointerUp(PointerEventData eventData){
        StopAllCoroutines();
        if (itemInfoUI != null)
        {
            Destroy(itemInfoUI.gameObject);
            itemInfoUI = null;
        }
        
    }

    IEnumerator ShowInfo()
    {
        yield return new WaitForSeconds(showInfoPopupTimeDelay);
        if (itemInfoUI == null)
        {
            GameObject infoPoup = Instantiate(infoPopupPrefabs, infoPopupPos);
            itemInfoUI = infoPoup.GetComponent<ItemInfoUI>();
            //itemInfoUI?.SetItemInfoData(itemData); 
        }
    }
    
    public void SetItemData(InventoryItemData inventoryItemData)
    {
        //itemData = inventoryItemData;
        itemImage.sprite = inventoryItemData.icon;
        itemQuantity.text = 1.ToString(); // hard code vi k biet lau dau ra
        itemImageObject.SetActive(true);
        itemQuantityObject.SetActive(true);
    }

    public void RemoveItemData()
    {
        itemImage.sprite = null;
        itemQuantity.text = 0.ToString(); // hard code vi k biet lau dau ra
        itemImageObject.SetActive(false);
        itemQuantityObject.SetActive(false);
    }
}
