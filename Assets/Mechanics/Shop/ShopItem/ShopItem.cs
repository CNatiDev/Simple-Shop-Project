using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour,IShopItem
{
    public float ItemPrice; // The price of the item.
    private Sprite ItemSprite;
    private GameObject OfferCanavas; //The offer canvas that will be spawned from the GameManager, assigned as OfferCanvas.
    public string Name;


    /// <summary>
    /// Initialization and spawning of the offer, assigning the camera, and setting the canvas to be initially false to make it visible only when the player enters the item's trigger.
    /// </summary>
    private void Start()
    {
        ItemSprite = GetComponent<SpriteRenderer>().sprite;
        OfferCanavas = Instantiate(GameManager.Instance.UiOfferPrefab, transform.position, Quaternion.identity,transform);
        OfferCanavas.GetComponent<Canvas>().worldCamera = Camera.main;
        OfferCanavas.SetActive(false);
        CheckPrice();
    }
    /// <summary>
    /// In the Buy function, we will check the budget, and if it's greater than or equal to the price, we will equip the inventory and update the budget.
    /// </summary>
    public void Buy()
    {
        
        if (GameManager.Instance.PlayeBudget >= ItemPrice)
        { 
            InventoryManager.Instance.EquipInventory(ItemSprite, Name, ItemPrice);
            GameManager.Instance.PlayeBudget -= ItemPrice;
            GameManager.Instance.BudgetText.text = GameManager.Instance.PlayeBudget.ToString();
            CheckPrice();
        }
    }
    public void DisplayOffer(bool show)
    {
        OfferCanavas.SetActive(show);
        CheckPrice();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DisplayOffer(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DisplayOffer(false);
    }
    public void CheckPrice()
    {// We check if there is enough budget to make the purchase, and if not, we will set the UI buy button's interactability to false.
        if (GameManager.Instance.PlayeBudget < ItemPrice)
            OfferCanavas.GetComponent<OfferManager>().BuyButton.interactable = false;
        else
            OfferCanavas.GetComponent<OfferManager>().BuyButton.interactable = true;

    }


}
