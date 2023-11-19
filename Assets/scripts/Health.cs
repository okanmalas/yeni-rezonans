using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int max_health = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Heal(10);
        }
    }
    public void SetHealth(int maxHealth, int health)
    {
        this.max_health = maxHealth;
        this.health = health;
    }
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Herhangi bir hasar yemiyor");
        }
        this.health -= amount;
        
        if (health <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Herhangi bir sağlık alınmadı");
        }
        bool wouldbeovermaxhealth = health + amount > max_health;
        if (wouldbeovermaxhealth)
        {
            this.health = max_health;

        }
        else
        {
            this.health += amount;
        }
    }
    private void Die()
    {
        Debug.Log("I am dead");
        Destroy(gameObject);
    }
}
