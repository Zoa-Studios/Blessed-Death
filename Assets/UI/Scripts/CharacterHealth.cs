using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public GameObject enemy;
    public GameObject player;
    public float Damage;


    public Slider healthbar;
    

    void Start()
    {
        MaxHealth = 100f;
        // Resets health to full on game load
        CurrentHealth = MaxHealth;

        healthbar.value = CalculateHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            DealDamage(6);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            DealDamage(Damage);
        }
    }
    void Update()
    {
    }

    void DealDamage(float damageValue)
    {
        // Deduct the damage dealt from the character's health
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        // If the character is out of health, die!
        if (CurrentHealth <= 0)
            Die();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }


    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("Parmigiana ehm... Sei morto!");
    }
}
