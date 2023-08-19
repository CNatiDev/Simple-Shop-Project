using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory _instance;
    public static PlayerInventory Instance
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
    public SpriteRenderer Hood;
    public void Equip(Sprite item, string itemName)
    {
        switch(itemName)
        {
            case "hood":
                Hood.sprite = item;
                Debug.Log("buy" + item.name);
                break;
        }
    }
}
