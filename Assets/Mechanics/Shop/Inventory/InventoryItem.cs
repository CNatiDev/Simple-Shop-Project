using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{   
    [HideInInspector] public Sprite Item;
    [HideInInspector] public string ItemName;
    [HideInInspector] public float Price;
    public void Equip()
    {
        InventoryManager.Instance.EquipPlayer(Item, ItemName);
    }
    public void Sell()
    {
        GameManager.Instance.PlayeBudget += Price;
        GameManager.Instance.BudgetText.text = GameManager.Instance.PlayeBudget.ToString();
        GetComponent<Image>().sprite = null;
        ItemName = null;
        Item = null;
        Price = 0;
    }
}
