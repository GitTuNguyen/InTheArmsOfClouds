using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public ItemManager itemManager;
    public List<CraftingRecipe> recipes = new List<Recipe>();

    public void CraftItem(List<Item> items)
    {
        foreach (CraftingRecipe recipe in recipes)
        {
            if (CheckRecipe(recipe, items))
            {
                // Nếu đủ tài nguyên, thực hiện craft item và thêm vào inventory
                inventoryManager.AddItem(recipe.craftedItem);
                // Loại bỏ tài nguyên đã sử dụng
                foreach (Item requiredItem in recipe.requiredItems)
                {
                    inventoryManager.RemoveItem(requiredItem);
                }
                // Thực hiện các hiệu ứng khác nếu cần
                ApplyEffects(recipe.craftedItem);
                break; // Nếu chỉ muốn craft 1 item
            }
        }
    }

    private bool CheckRecipe(CraftingRecipe recipe, List<Item> items)
    {
        // Kiểm tra xem có đủ tài nguyên không
        foreach (Item requiredItem in recipe.requiredItems)
        {
            if (!items.Contains(requiredItem))
            {
                return false;
            }
        }
        return true;
    }

    private void ApplyEffects(Item craftedItem)
    {
        
    }
}
