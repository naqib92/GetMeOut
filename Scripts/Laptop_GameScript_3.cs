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
    public GameObject enterA_Number;
    private PlayerStatusScript playerStatus; //playerStatus.GetDamage(damage);
    private HealthBar_BlurScript healthbar_blur;
    public Camera fpsCam;



    private bool Laptop_isInsideTrigger = false;
    public string currentAnswer3 = "24";
    public bool correct = false;
    public static bool KeyCard_To_Laptop;
    public int damage = 5;

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

    // if raycast hits the laptop collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Game_Laptop")
            {
                Laptop_isInsideTrigger = true;
                if (KeyCard_To_Laptop == true)
                {

                    Laptop_OpenPanel3.SetActive(true);
                    _animator.SetBool("Laptop_on", true);
                }
            }
            if (hit.collider.gameObject.tag == "Book_binary")//in case raycast hits the open book then deactivate the laptop panel
            {
                Laptop_OpenPanel3.SetActive(false);
            }


        }
        else
        {
            Laptop_isInsideTrigger = false;
            Laptop_OpenPanel3.SetActive(false);

            laptop_myNumber.text = "";//reset input field when raycast looks away from collider
            wrongAnswer.SetActive(false);// deactivate wrong answer when raycast looks away from collider
            _animator.SetBool("Laptop_on", false);
            enterA_Number.SetActive(false);
        }
    }

    // if player is insideTrigger show panel keyboard
    void InsideTrigger()
    {
        
        if (KeyCard_To_Laptop == true)
        {

            if (Laptop_isInsideTrigger)
            {
             
                if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    keypadInput("0");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {

                    keypadInput("1");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    keypadInput("2");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    keypadInput("3");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    keypadInput("4");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    keypadInput("5");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    keypadInput("6");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
                {
                    keypadInput("7");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    keypadInput("8");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
                {
                    keypadInput("9");
                    wrongAnswer.SetActive(false);
                    enterA_Number.SetActive(false);
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
                    else if (laptop_myNumber.text == "")
                    {
                        enterA_Number.SetActive(true);
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
                StartCoroutine(ShowSuccess());
                shownMinimizedKeycard004.SetActive(false);//for deactivating panel_keycard04_minimized when answer is correct
                keycardIsActive_minimized004.SetActive(true); //to activate panel keycardIsActive_minimized when answer is correct

                WeaponSafe_CorridorScript.keycardIsActiv = true; // key card is now activ for the door to open
                WeaponSafe_CorridorScript.KeyCard_To_Laptop = false;// dont show key needs to be activated since the answer is correct   
                _animator.SetBool("Laptop_on", false);
            }
            if (correct && Laptop_isInsideTrigger == false)
            {
               
                shownMinimizedKeycard004.SetActive(false);//for deactivating minimized panel keycard04(key card obtained) when answer is correct
                keycardIsActive_minimized004.SetActive(true);//to activate minimized panel "key card is activ" when answer is correct

            }

        }

    }


    //show the the panel "key card is activ" for some seconds and then deactivate
    IEnumerator ShowSuccess()
    {
        Reward_OpenPanel3.SetActive(true);
        yield return new WaitForSeconds(2f);
        Reward_OpenPanel3.SetActive(false);
       // shownMinimizedKeycard004.SetActive(false);//for deactivating minimized panel keycard04(key card obtained) when answer is correct
       // keycardIsActive_minimized004.SetActive(true);//to activate minimized panel "key card is activ" when answer is correct
    }




    // Update is called once per frame
    void Update()
    {
        _RaycastHit();
        InsideTrigger();
    }



    //Numbers are passed from mouse or keyboard when clicked
    public void keypadInput(string laptop__key)
    {

        laptop_number = laptop__key;
        laptop_myNumber.text += laptop_number;
        wrongAnswer.SetActive(false);
        enterA_Number.SetActive(false);

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
