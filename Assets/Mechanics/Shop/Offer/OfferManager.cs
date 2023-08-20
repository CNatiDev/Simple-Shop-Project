using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferManager : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Price;
    public Button BuyButton;
    private void Start()
    {
        var Item = GetComponentInParent<ShopItem>();
        Price.text = Item.ItemPrice.ToString();
        BuyButton.onClick.AddListener(GetComponentInParent<IShopItem>().Buy);
        Title.text = Item.Name;
        Item.CheckPrice();

    }
}
