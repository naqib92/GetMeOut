using UnityEngine;
using System.Collections;

//Enemy healthbar should always position itself to the fps main camera. 
//Goes to EnemyCanvas
public class CameraFacingBillboardScript : MonoBehaviour
{

    void Update()
    {
        //transform.LookAt(Camera.current.transform); // the object that is looking to the camera is mirrowed

        //FIXED
        //transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.current.transform.position);
    }
}

/**
Private Transform Player;

    void Start()
{
    PlayerPlayer = GameObject.Find("FirstPersonCharacter").GetComponent<Transform>();
}
    void Update()
    {
    transform.LookAt(player)
    }
**/
