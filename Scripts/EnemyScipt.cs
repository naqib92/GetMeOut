using UnityEngine;
using UnityEngine.UI;
public class EnemyScipt : MonoBehaviour {

    public float maxHealth = 50f; // healt of the enemy
    public float currentHealth = 0f;
    public Image bar;

    void Start()
    {
        //Image bar - full bar at start
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    //Image bar
    public void healthBar()
    {
        bar.fillAmount = currentHealth / maxHealth; // procent value from 0 - 1. example -  60/100 = 0,6% on the bar      
    }


    void Die()
    {
        Destroy(gameObject);
    }

}
