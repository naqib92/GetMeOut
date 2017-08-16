using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shielded_EnemyScript : MonoBehaviour {

    public GameObject enemy;                     // when shield is destroyed change the tag(shielded_enemy) of monster(4) to tag(enemy), 
                                                 //so that if(hit.collider.tag == "enemy") can be executed in WeaponGunScript.cs
    public GameObject shieldEffect;//using SharpRing effect

    public float maxHealthShield = 30f;
    private float currentHealthShield = 0f;
    public Image barShield;

    void Start()
    {
        //Image bar - full bar at start
        currentHealthShield = maxHealthShield;
    }

    public void shield()
    {
        GameObject shieldGameObject = Instantiate(shieldEffect, transform.position, transform.rotation) as GameObject;
        Destroy(shieldGameObject, 2f);
    }



    public void TakeDamageShield(float damageShield)
    {
        currentHealthShield -= damageShield;
        healthBarShield();
        if (currentHealthShield <= 0f)
        {
            enemy.tag = "enemy";// execute WeaponGunscripts.cs -> if(hit.collider.tag == "enemy")
        }
    }

    //Image bar
    void healthBarShield()
    {
        barShield.fillAmount = currentHealthShield / maxHealthShield; // procent value from 0 - 1. example -  60/100 = 0,6% on the bar      
    }
}
