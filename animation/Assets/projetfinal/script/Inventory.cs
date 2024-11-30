using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _CountCoin;
    
    [SerializeField] private TextMeshProUGUI _CountCoinText;

    
    public static Inventory _Instance;

    private void Awake()
    {
        if (_Instance != null)
        {

            Debug.Log("The is more inventory instance in the scene");
            return;
        }
        _Instance = this;
    }

    public void Addcoin(int coin)
    {

        _CountCoin += coin;

        _CountCoinText.text = _CountCoin.ToString();

       
    }
}
