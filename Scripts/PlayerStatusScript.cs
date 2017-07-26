using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatusScript : MonoBehaviour {
    public Animator _animator;

    //Image bar
    public float maxHealth = 100;
    public float currentHealth = 0;
    public Image bar;


   


    //health text
    public Text healthText;
    public string log_info;




    // Use this for initialization
    void Start () {

        _animator = GetComponent<Animator>();

        //Image bar - full bar at start
        currentHealth = maxHealth;


        //health text--show 100 at start
        healthText.text = "Health: " + currentHealth.ToString();
    }




    public IEnumerator onOff_Healthbar()
    {
        
        bar.enabled = false;
        yield return new WaitForSeconds(0.10f);
        bar.enabled = true;
        
    }


    public void GetDamage(int damage)
    {
       
        StartCoroutine(onOff_Healthbar());
        currentHealth -= damage;
        healthText.text = "Health: " + currentHealth.ToString();//health text
        log_info = currentHealth.ToString();
        Debug.Log("Health" + log_info);

        healthBar();
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    //Image bar
    public void healthBar()
    {
        
        bar.fillAmount = currentHealth / maxHealth; // procent value from 0 - 1. example -  60/100 = 0,6% on the bar      
    }



}
