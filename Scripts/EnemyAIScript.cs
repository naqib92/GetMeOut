using UnityEngine;
using System.Collections;
/** Animation Bool States
 * isRunning   !!not used
 * isIdle      !!not used
 * isRunHit
 * isIdleHit
 * isWalking
 * isWalkHit
 * */



public class EnemyAIScript : MonoBehaviour
{
    public Transform player;//FPSController
    public Transform eyes;// A sphere with a disabled mesh renderer is used for the eyes(Radar)
    private Animator anim;
    private NavMeshAgent nav;

    private string state = "chooseA_SpotToWalk";
    private bool alive = true;
    private bool isOutside = false;
    private float wait;//when player out runs the enemy, the enemy chases the player for some time and looses interest
    private float standStill;// when enemy reaches path position, enemy should stay still for a certain amount of time and move after

    private float nearAttack_distance;//when enemy gets near the player 
    private float inFrontAttack_distance;//when enemy is in front of player
    private float outOfSight;//when player out runs the enemy, the enemy looses interest







    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 1.2f;     //enemy speed
    }

    //check if we can see the player
    public void CheckSight()
    {
        if (alive)
        {

            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, player.transform.position, out rayHit))
            {
                //print("hit" + rayHit.collider.gameObject.name); //show the name of the objects that where hit with the raycast


                if (rayHit.collider.gameObject.name == "FPSController")
                {

                    // if state variable hasnt been initiated with "inPlainSight", which it hasnt, then overwrite state variable with "chase". 
                    // This means any other state which is activ will be overwritten with state = "chase" in the moment raycast collides with the player
                    if (state != "inPlainSight")
                    {
                        state = "chase";
                        nav.speed = 3.5f;
                        wait = 10f;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(eyes.position, player.transform.position, Color.red);//draws a line in the scene window to show distance between player and enemy
        if (alive)
        {

            //walks randomly
            //chooses a spot to walk to
            if (state == "chooseA_SpotToWalk")
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                //pick a random place to walk
                Vector3 randomPos = Random.insideUnitCircle * 20f;//finding the random point in a certain radius of space
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);//Find a random position to walk to from the starting point in a radius of 20
                nav.SetDestination(navHit.position);
                standStill = 1f;
                state = "chooseAnotherSpot";
                
            }

            //chooses another spot to walk to 
            if (state == "chooseAnotherSpot")
            {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    Debug.Log("arrived");
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", true);

                    // when enemy reaches path position, enemy should stay still for a certain amount of time and move after
                    if (standStill > 0)
                    {
                        standStill -= Time.deltaTime;
                    }else
                    {
                        state = "chooseA_SpotToWalk";
                    }
                }


            }
            //chase
            if (state == "chase")
            {
                
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                nav.destination = player.transform.position;

                //when player out runs the enemy, the enemy looses interest
                //if player is out of the enemys field for a certain amount of time the enemy goes back patrolling
                outOfSight = Vector3.Distance(transform.position, player.transform.position);
                if (outOfSight > 20)
                {
                    Debug.Log("Player is out of enemies sight");
                    if (wait > 0f)
                    {
                        wait -= Time.deltaTime;
                    }else
                    {
                        Debug.Log("Enemy has stopped chasing you");
                        nav.speed = 1.2f;
                        state = "chooseAnotherSpot";
                    }


                    

                }



                //if enemy gets near the player start the walk hit animation
                nearAttack_distance = Vector3.Distance(transform.position, player.transform.position);
                if (nearAttack_distance < 5)
                {
                    anim.SetBool("isWalkHit", true);
                    anim.SetBool("isWalking", false);
                    if (nearAttack_distance < 3)// if enemy gets in front of the player
                    {
                        state = "inFrontPlayer";
                    }
                }
                else
                {
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isWalkHit", false);
                }


            }
            //when enemy is in front of player start the idle hit animation and damage the player
            if (state == "inFrontPlayer")
            {
                inFrontAttack_distance = Vector3.Distance(transform.position, player.transform.position);
                if (inFrontAttack_distance < 3)
                {
                   // Debug.Log("damage");
                    anim.SetBool("isWalkHit", false);
                    anim.SetBool("isIdleHit", true);
                }else
                {
                    anim.SetBool("isWalkHit", true);
                    anim.SetBool("isIdleHit", false);
                    state = "chase";
                }


            }
            // nav.SetDestination(player.transform.position);




        }

    }
}


