using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Player inventory is null");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    [Tooltip("SpriteRenderer attached to the player, change their sprites when equipping an item.")]
    [Header("Body Items")]
    public SpriteRenderer Hood;
    public SpriteRenderer Torso;
    public SpriteRenderer BootR;
    public SpriteRenderer BootL;
    public SpriteRenderer WirstL;
    public SpriteRenderer WirstR;
    public SpriteRenderer Face;
    public SpriteRenderer Shoulder;
    public SpriteRenderer Pelvis;

    [Tooltip("Items in the UI inventory are automatically updated with the sprites of the items in the scene that will be purchased")]
    [Header("Inventory Items")]
    public Image[] InventoryIcon;

    [HideInInspector] public int lastIcon = 0;
    [HideInInspector] public bool IsFull = false; //Check if the inventory is full.

    /// <summary>
    /// The method is used to send the necessary information to the InventoryItem, including the sprite, sprite name, price, and to add the item to the inventory.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="itemName"></param>
    /// <param name="itemPrice"></param>
    public void EquipInventory(Sprite item, string itemName, float itemPrice)
    {   //Checking if there's still space in the inventory to add a new item.
        if (lastIcon + 1 <= InventoryIcon.Length&&!IsFull)
        {
            IsFull = false;
        }
        else
        { 
            IsFull = true;
        }
        if (!IsFull)
        {
            AddItem(item, itemName, itemPrice, lastIcon);
            lastIcon++;
        }
        // If it's full, we check if the player has sold something, and if yes, we identify the available slots and load the sprite there.
        if (IsFull&&lastIcon+1<=InventoryIcon.Length)
        {
            for (int i=0;i<InventoryIcon.LongLength;i++)
            {
                if (InventoryIcon[i].sprite == null)
                {
                    AddItem(item, itemName, itemPrice, i);
                    break;
                }
            }
        }
    }


    public void EquipPlayer(Sprite item, string itemName)
    {   // Cecking the player's name in order to know which clothing they are equipping.
        switch (itemName)
        {
            case "hood":
                if (Hood != null)
                    Hood.sprite = item;
                break;
            case "torso":
                if (Torso != null)
                    Torso.sprite = item;
                break;
            case "boot L":
                if (BootL != null)
                    BootL.sprite = item;
                break;
            case "boot R":
                if (BootR != null)
                    BootR.sprite = item;
                break;
            case "wirst L":
                if (WirstL != null)
                    WirstL.sprite = item;
                break;
            case "wirst R":
                if (WirstR != null)
                    WirstR.sprite = item;
                break;
            case "pelvis":
                if (Pelvis != null)
                    Pelvis.sprite = item;
                break;
            case "face":
                if (Face != null)
                    Face.sprite = item;
                break;
            case "shoulder":
                if (Shoulder != null)
                    Shoulder.sprite = item;
                break;
        }
    }

    //Avoid violating the DRY (Don't Repeat Yourself) principle, we will create a method for adding items.
    void AddItem(Sprite item, string itemName, float itemPrice, int index)
    {
        InventoryIcon[index].sprite = item;
        InventoryIcon[index].GetComponent<InventoryItem>().Item = item;
        InventoryIcon[index].GetComponent<InventoryItem>().ItemName = itemName;
        InventoryIcon[index].GetComponent<InventoryItem>().Price = itemPrice;
    }
}
