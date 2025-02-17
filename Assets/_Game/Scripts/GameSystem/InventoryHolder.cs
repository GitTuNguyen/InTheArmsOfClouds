using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    public static InventoryHolder Instance;
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    public InventorySystem InventorySystem => inventorySystem;

    //public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;
    private void Awake() {
        Instance = this;
        inventorySystem.InitInventorySystem(inventorySize);
    }

    public void ClearInventory()
    {
        inventorySystem.ClearInventory();
    }

    public void RemoveItemAtIndex(int index)
    {
        inventorySystem.RemoveFromInventory(index);
    }
}
