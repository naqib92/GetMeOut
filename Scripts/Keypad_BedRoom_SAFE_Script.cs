using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Keypad_BedRoom_SAFE_Script : MonoBehaviour
{

    public GameObject openPanel_Keypad = null;
    public Animator _animator;
    public GameObject destroyPasswordMinimalized;//using tag to destroy
    public Camera fpsCam;
    public Collider keycard_Terminal1;// activate the keycard collider when door is opened

    public string currentPassword_BedRoom = "000";
    public bool bedroom_inTrigger;
    public bool bedroom_doorOpended;
    public bool bedroom_keyPadScreen;
    //public Transform DoorHolder;



    //keypad input
    string bedroom_number = null;
    public InputField bedroom_myNumber = null;





    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
     
    }





    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "safe_Bedroom")
            {
                bedroom_inTrigger = true;
                openPanel_Keypad.SetActive(true);
            }
            if (hit.collider.gameObject.tag == "chestdrawer_Bedroom")// in case raycast hits the chestdrawer Safe then deactivate the bedroom safe panel
            {
                openPanel_Keypad.SetActive(false);
            }

        }
        else
        {
            bedroom_inTrigger = false;
            bedroom_keyPadScreen = false;
            openPanel_Keypad.SetActive(false);

        }



        //if inside the trigger 
        if (bedroom_inTrigger)
        {
            
            //keyboard
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                keypadInput("0");

            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                keypadInput("1");
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                keypadInput("2");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                keypadInput("3");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                keypadInput("4");
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                keypadInput("5");
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                keypadInput("6");
            }

            if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            {
                keypadInput("7");
            }

            if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                keypadInput("8");
            }

            if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
            {
                keypadInput("9");
            }
            if (Input.GetKeyDown(KeyCode.Hash))//hash key not working. Maybe a bug in unity 5.4.0
            {
                keypadInput("#");
            }
            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                keypadInput("*");
            }
            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
            {

                bedroom_myNumber.text = "";    

            }

        }


     


        if (bedroom_myNumber.text == currentPassword_BedRoom)
        {
            bedroom_doorOpended = true;
            

        }
        if (bedroom_doorOpended)
        {

            // transform.Find("opener").GetComponent<Animation>().Play("Safe_Handel_Rotation");

            
            //var newRot = Quaternion.RotateTowards(DoorHolder.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            // DoorHolder.rotation = newRot;


            _animator.SetBool("Safe_DoorOpen_Bedroom", true);
            openPanel_Keypad.SetActive(false);
            bedroom_inTrigger = false;
            bedroom_keyPadScreen = false;
            Destroy(destroyPasswordMinimalized);
            keycard_Terminal1.enabled = true;//collider is enabled
        }

    }

    //Number is passed from on Click() function when clicked with mouse 
    public void keypadInput(string bedroom_key)
    {

        bedroom_number = bedroom_key;
        bedroom_myNumber.text += bedroom_number;
        
        if(bedroom_key == "d")
        {
            bedroom_myNumber.text = "";
        }
           
    }
}

