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
    public GameObject MainPlayer;
    public float PlayeBudget;
    public TextMeshProUGUI BudgetText;
    private void Start()
    {
        BudgetText.text = PlayeBudget.ToString();
    }
    

}
