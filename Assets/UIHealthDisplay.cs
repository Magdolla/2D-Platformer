using TMPro;
using UnityEngine;
using static PlayerHealth;


public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public PlayerHealth playerHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitilised += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
        HealthText.text = newHealth.ToString();
    }
    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        HealthText.text = newHealth.ToString();
    }
   
   
   
}
