using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponGunAmmoStatus : MonoBehaviour
{

    //Image bar
    public float maxAmmo = 100;
    public float currentAmmo = 0;
    public float fillAmmo = 10;
    public Image bar;


    // Use this for initialization
    void Start()
    {

        //Image bar - full bar at start
        currentAmmo = maxAmmo;
    }

    IEnumerator refillAmmo()
    {

        
        yield return new WaitForSeconds(2f);
        currentAmmo = maxAmmo;



    }

    public void LowerAmmo(float lowerAmmo)
    {


        currentAmmo -= lowerAmmo;
        ammoBar();

    }


    //Image bar
    public void ammoBar()
    {
        bar.fillAmount = currentAmmo / maxAmmo; // procent value from 0 - 1. example -  60/100 = 0,6% on the bar      
    }

    void Update()
    {
        if (currentAmmo == 0)
        {
            StartCoroutine(refillAmmo());
            Debug.Log("fill");
            
        }
    }
}
