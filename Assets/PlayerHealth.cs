using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
  
{
    public float MaxHealth = 100;
    private float Health;
    private bool CanReciveDamage = true;
    public float InvincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if(CanReciveDamage)
        {
            Health -= damage;
            OnHealthChanged?.Invoke(Health, -damage);
            CanReciveDamage = false;
            StartCoroutine(InvincilibityTimer(InvincibilityTimer, ResetInvincibility));
        }
       
        Debug.Log(Health);
    }

    IEnumerator InvincilibityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        CanReciveDamage = true;
    }
    public void AddHealth(float AddHealth)
    {
        Health += AddHealth;
        OnHealthChanged?.Invoke(Health, AddHealth);
        Debug.Log(Health);
    }
}
