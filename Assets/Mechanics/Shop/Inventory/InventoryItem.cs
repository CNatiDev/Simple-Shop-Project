using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{   
    [HideInInspector] public Sprite Item; // We store the sprite to equip the necessary SpriteRenderer on the player's body.
    [HideInInspector] public string ItemName;// We store the name to know what type of item it is and where to implement it.
    [HideInInspector] public float Price; // We store the price to know how much to subtract and add to the budget.
    /// <summary>
    /// The method is used for the Equip UI button in the inventory, to send the necessary information to the manager for equipping.
    /// </summary>
    public void Equip()
    {
        InventoryManager.Instance.EquipPlayer(Item, ItemName);
    }
    /// <summary>
    /// The method is used for the Sell UI button in the inventory, to send the necessary information to the managers for selling. And also to nullify the name, price, and sprite, in order to make space for another one.
    /// </summary>
    public void Sell()
    {
        GameManager.Instance.PlayeBudget += Price;
        GameManager.Instance.BudgetText.text = GameManager.Instance.PlayeBudget.ToString();
        GetComponent<Image>().sprite = null;
        InventoryManager.Instance.lastIcon -= 1;
        ItemName = null;
        Item = null;
        Price = 0;
    }
}
