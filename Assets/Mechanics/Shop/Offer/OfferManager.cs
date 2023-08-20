using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferManager : MonoBehaviour
{
    public TextMeshProUGUI Title; // The offer's title where the item name is displayed.
    public TextMeshProUGUI Price; // The price text of the item for the player to see.
    public Button BuyButton; // The purchase button that automatically add the item to the inventory.
    
    /// <summary>
    /// Initialization of the title, price, and adding the 'Buy' function that is part of the IShopItem interface.
    /// </summary>
    private void Start()
    {   
        var Item = GetComponentInParent<ShopItem>();
        Price.text = Item.ItemPrice.ToString();
        BuyButton.onClick.AddListener(GetComponentInParent<IShopItem>().Buy);
        Title.text = Item.Name;
        Item.CheckPrice();

    }

}
