using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null)
                Debug.Log("GameManager is null");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// In the Game Manager, we will store the main character, their budget, the budget text, and the general offer. By using the Singleton pattern
    /// , we can access these from scripts to retrieve and set information.
    /// </summary>
    public GameObject MainPlayer;
    public float PlayeBudget;
    public TextMeshProUGUI BudgetText;
    public GameObject UiOfferPrefab;
    private void Start()
    {
        BudgetText.text = PlayeBudget.ToString();
    }
    

}
