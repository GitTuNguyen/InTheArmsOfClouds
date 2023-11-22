using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour,IPointerClickHandler
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;
    private SphereCollider myCollider;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!InventoryHolder.Instance)
        {
            Debug.Log("inventory = null");
            return;
        }
        Debug.Log("inventory != null");

        if(InventoryHolder.Instance.InventorySystem.AddSpaceShip(ItemData)){
            Debug.Log("Add spaceship to inventory");
            Destroy(this.gameObject);
            Debug.Log("Destroy spaceship");
        }else if (InventoryHolder.Instance.InventorySystem.AddToInventory(ItemData, 1))
        {
            Debug.Log("Add item to inventory");
            Destroy(this.gameObject);
            Debug.Log("Destroy item");
        }
        
    }


    private void Awake(){
        myCollider = GetComponent<SphereCollider>();
        //myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }
    private void OnTriggerEnter(Collider other) {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if(!inventory)
        {
            Debug.Log("inventory = null");
            return;
        }
        Debug.Log("inventory != null");
        if(inventory.InventorySystem.AddToInventory(ItemData, 1)){
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
    // private void Update() {

    //         if (Input.GetKeyDown(KeyCode.Alpha1))
    //         {
    //             Debug.Log(" pressed 1");
    //             GameObject newObject = new GameObject("NewObject");
    //             InventoryHolder inventoryHolderComponent = newObject.AddComponent<InventoryHolder>();

    //             if(!inventoryHolderComponent) {
    //                 Debug.Log(" inventory = null");
    //                 return;
    //             }

    //             Debug.Log(" add 1 meat to Inventory");
    //             inventoryHolderComponent.InventorySystem.AddToInventory(ItemData, 1);
    //         }

    // }
}
