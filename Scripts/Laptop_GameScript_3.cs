using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Laptop_GameScript_3 : MonoBehaviour {

    // atoms are composed of

    private Animator _animator;
    public GameObject Laptop_OpenPanel3;
    public GameObject Reward_OpenPanel3;
    public GameObject keycardIsActive_minimized004;// to activate panel keycardIsActive_minimized04 when answer is correct
    public GameObject shownMinimizedKeycard004; //for deactivating panel_keycard04_minimized when answer is correct
    public GameObject wrongAnswer;
    private PlayerStatusScript playerStatus; //playerStatus.GetDamage(damage);
    private HealthBar_BlurScript healthbar_blur;
    public Camera fpsCam;



    private bool Laptop_isInsideTrigger = false;
    public string currentAnswer3 = "2";
    public bool correct = false;
    public static bool KeyCard_To_Laptop;
    public int damage = 20;

    //keypad input
    string laptop_number = null;
    public InputField laptop_myNumber = null;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatusScript>();
        healthbar_blur = GetComponent<HealthBar_BlurScript>();
    }




    // Update is called once per frame
    void Update()
    {



        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Game_Laptop")
            {
                Laptop_isInsideTrigger = true;
                if (KeyCard_To_Laptop == true)
                {

                    Laptop_OpenPanel3.SetActive(true);// panel can now being seen
                    _animator.SetBool("Laptop_on", true);
                }
            }


        }
        else
        {
            Laptop_isInsideTrigger = false;
            Laptop_OpenPanel3.SetActive(false);// panel is invincible

            laptop_myNumber.text = "";
            wrongAnswer.SetActive(false);
            _animator.SetBool("Laptop_on", false);

        }




        if (KeyCard_To_Laptop == true)
        {

            if (Laptop_isInsideTrigger)
            {
                Laptop_OpenPanel3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    keypadInput("0");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {

                    keypadInput("1");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    keypadInput("2");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    keypadInput("3");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    keypadInput("4");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    keypadInput("5");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    keypadInput("6");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
                {
                    keypadInput("7");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    keypadInput("8");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
                {
                    keypadInput("9");
                    wrongAnswer.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    laptop_myNumber.text = "";
                    wrongAnswer.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    if (laptop_myNumber.text == currentAnswer3)
                    {
                        Laptop_OpenPanel3.SetActive(false);
                        Laptop_OpenPanel3 = null;
                        correct = true;
                    }


                    else
                    {
                        //laptop_myNumber.text = "wrong answer";
                        wrongAnswer.SetActive(true);
                        playerStatus.GetDamage(damage);
                        healthbar_blur.showBlur();
                    }
                }
            }


            if (correct && Laptop_isInsideTrigger)
            {
                Reward_OpenPanel3.SetActive(true);
                shownMinimizedKeycard004.SetActive(false);//for deactivating panel_keycard04_minimized when answer is correct
                keycardIsActive_minimized004.SetActive(true); //to activate panel keycardIsActive_minimized when answer is correct

                WeaponSafe_CorridorScript.keycardIsActiv = true; // key card is now activ for the door to open
                WeaponSafe_CorridorScript.KeyCard_To_Laptop = false;// dont show key needs to be activated since the answer is correct   
                _animator.SetBool("Laptop_on", false);
            }
            if (correct && Laptop_isInsideTrigger == false)
            {
                Reward_OpenPanel3.SetActive(false);
                shownMinimizedKeycard004.SetActive(false);//for deactivating panel_keycard04_minimized when answer is correct
                keycardIsActive_minimized004.SetActive(true);//to activate panel keycardIsActive_minimized when answer is correct

            }

        }

    }



    //Numbers are passed from mouse or keyboard when clicked
    public void keypadInput(string laptop__key)
    {

        laptop_number = laptop__key;
        laptop_myNumber.text += laptop_number;
        wrongAnswer.SetActive(false);

        //delete button
        if (laptop__key == "d")
        {
            laptop_myNumber.text = "";
            wrongAnswer.SetActive(false);
        }

    }

    //enter button
    //when enter is pressed using the mouse, e is passed to keypadInput(string laptop_key) 
    public void keypadInputEnter(string laptop__key)
    {


        if (laptop__key == "e")
        {
            if (laptop_myNumber.text == currentAnswer3)
            {

                Laptop_OpenPanel3.SetActive(false);
                Laptop_OpenPanel3 = null;
                correct = true;

            }

            else
            {
                //laptop_myNumber.text = "wrong answer";
                wrongAnswer.SetActive(true);
                playerStatus.GetDamage(damage);
                healthbar_blur.showBlur();
            }

        }

        if (correct && Laptop_isInsideTrigger)
        {
            Reward_OpenPanel3.SetActive(true);
            shownMinimizedKeycard004.SetActive(false);//for deactivating panel_keycard04_minimized when answer is correct
            keycardIsActive_minimized004.SetActive(true);//to activate panel keycardIsActive_minimized when answer is correct
            WeaponSafe_CorridorScript.keycardIsActiv = true;// key card is now activ for the door to open
            WeaponSafe_CorridorScript.KeyCard_To_Laptop = false;// dont show key needs to be activated since the answer is correct
            _animator.SetBool("Laptop_on", false);
        }
        if (correct && Laptop_isInsideTrigger == false)
        {
            Reward_OpenPanel3.SetActive(false);
            shownMinimizedKeycard004.SetActive(false);//for deactivating panel_keycard04_minimized when answer is correct
            keycardIsActive_minimized004.SetActive(true);//to activate panel keycardIsActive_minimized when answer is correct

        }

    }
}
