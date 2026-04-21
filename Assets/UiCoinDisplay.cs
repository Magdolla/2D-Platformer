using TMPro;
using UnityEngine;

public class UiCoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public PlayerHealth CoinCoin; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinCoin.OnCoinChanged += OnCoinChanged;
     
    }

    public void OnCoinChanged(float addcoin)
    { 
    CoinText.text = addcoin.ToString();
    }
}
