using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour,IShopItem
{
    public float ItemPrice;
    private Sprite ItemSprite;
    private GameObject OfferCanavas;
    public string Name;
    public GameObject UiPrefab; 
    private void Start()
    {
        ItemSprite = GetComponent<SpriteRenderer>().sprite;
        OfferCanavas = Instantiate(UiPrefab, transform.position, Quaternion.identity,transform);
        OfferCanavas.GetComponent<Canvas>().worldCamera = Camera.main;
        OfferCanavas.SetActive(false);
        CheckPrice();
    }
    public void Buy()
    {
        
        if (GameManager.Instance.PlayeBudget >= ItemPrice)
        { 
            GameManager.Instance.MainPlayer.GetComponent<PlayerInventory>().Equip(ItemSprite, Name);
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
    {
        if (GameManager.Instance.PlayeBudget < ItemPrice)
            OfferCanavas.GetComponent<OfferManager>().BuyButton.interactable = false;
    }


}
