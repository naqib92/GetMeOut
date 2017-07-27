using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//get rid of this error if occurs: UnityEditor.AsyncHTTPClient:Done(State, Int32)
//Edit -> Preferences -> Show Asset Store Search Hits -> disable checkbox

public class WeaponGunScript : MonoBehaviour {

    public float damage = 10f; // damage inflicted to the enemy
    public float range = 100f; // distance that can be fired to
    public float impactForce = 30f;

    public float maxAmmo = 100f;
    public float currentAmmo;
    public float declineAmmo = 20f;
    public float reloadTime = 3f;
    private bool isReloading = false;


    public Camera fpsCam;// used to shoot a Raycast from the camera
    public ParticleSystem muzzleFlash;//particle effect Afterburner
    public GameObject impactEffect;//enemy has to have a rigid body// impact effect(particle effect Shockwave) after enemy is hit with a raycast 
    private WeaponGunAmmoStatus wGAS;
    public Image bar;

    // Use this for initialization
    void Start ()
    {
        //wGAS = GetComponent<WeaponGunAmmoStatus>();
        currentAmmo = maxAmmo;
    }


    // Update is called once per frame
    void Update()
    {
        ammoBar();

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            //lowerAmmo();
        }
    }


    void shoot()
    {
        currentAmmo -= declineAmmo;

        muzzleFlash.Play();
        RaycastHit hit; //store information about what we hit with out ray

        //to shoot out a ray
        //fpsCam.transform.position -> shoot out a ray starting at the position of our camera
        //fpsCam.transform.position -> shoot the ray in the direction we are facing
        //out hit -> gather information of what we hit and put it in the RaycastHit hit variable
        //range -> if objects are further away than the range unit, we arent able to hit them
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //show the name of the object that has been hit in the console
           // Debug.Log(hit.transform.name);

            // subtract amount from the enemys health
            EnemyScipt enemy = hit.transform.GetComponent<EnemyScipt>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            
            //push an object with a rigid body backwards when hit
            //-hit.normal -> push backwards
            if(hit.rigidbody != null)//if an object has a rigid body 
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            //if an object is hit, show the shockwave
            //hit.point -> point of impact
            //Quaternion.LookRotation(hit.normal) -> dont understand
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;

            //destroy every instanitaed object after 2 seconds. This is done so that the unity hierarchy  
            //doesnt get full with instantiated objects and also to make sure memory does not get full
            Destroy(impactGameObject, 2f);


        } 
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }



    //Image bar
    public void ammoBar()
    {
        bar.fillAmount = currentAmmo / maxAmmo; // procent value from 0 - 1. example -  60/100 = 0,6% on the bar      
    }
    /**
        void lowerAmmo()
        {
            wGAS.LowerAmmo(declineAmmo);
        }
    **/
}
