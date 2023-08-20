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

    [Header("Inventory Items")]
    public Image[] InventoryIcon;
    int lastIcon = 0;
    public void EquipInventory(Sprite item, string itemName, float itemPrice)
    {
        if (lastIcon + 1 <= InventoryIcon.Length)
        {
            InventoryIcon[lastIcon].sprite = item;
            InventoryIcon[lastIcon].GetComponent<InventoryItem>().Item = item;
            InventoryIcon[lastIcon].GetComponent<InventoryItem>().ItemName = itemName;
            InventoryIcon[lastIcon].GetComponent<InventoryItem>().Price = itemPrice;
            lastIcon++;
        }
    }
    public void EquipPlayer(Sprite item, string itemName)
    {
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
}
