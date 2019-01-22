using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIstats : MonoBehaviour {
    public int maxHealth;
    public int DamageTaken;
    public int DamageGiven;
    public float currentHealth;
    // Use this for initialization

    void Start() {
        currentHealth = maxHealth;
    
    }

    // Update is called once per frame
    void Update() {

    
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth += amount;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyAI")
        {
            currentHealth -= DamageTaken;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
