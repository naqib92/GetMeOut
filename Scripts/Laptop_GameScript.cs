using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Laptop_GameScript : MonoBehaviour {

    // q: what is binary 010


    private Animator _animator;
    public GameObject Laptop_OpenPanel;
    public GameObject Reward_OpenPanel;
    public GameObject passwordShownMinimalized;
    public GameObject wrongAnswer = null;
    private PlayerStatusScript playerStatus; //playerStatus.GetDamage(damage);
    private HealthBar_BlurScript healthbar_blur;
    public Camera fpsCam;

    private bool Laptop_isInsideTrigger = false;
    public string currentAnswer = "2";
    public bool correct = false;
    public static bool putOffPanel_Game1;// in case this gamescript wasnt played then dont show the panel 
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






// if raycast hits the laptop collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Game_Laptop")
            {
                if (putOffPanel_Game1 == true)// in case this gamescript wasnt played then dont show the panel
                {
                    Laptop_OpenPanel.SetActive(false);
                }
                else
                {
                    Laptop_isInsideTrigger = true;
                    Laptop_OpenPanel.SetActive(true);
                    _animator.SetBool("Laptop_on", true);
                }
            }


        }
        else
        {
            Laptop_isInsideTrigger = false;
            Laptop_OpenPanel.SetActive(false);
            _animator.SetBool("Laptop_on", false);
            laptop_myNumber.text = "";
            wrongAnswer.SetActive(false);

        }
    }


    // if player is insideTrigger show panel keyboard
    void InsideTrigger()
    {
        if (Laptop_isInsideTrigger)
        {
            Laptop_OpenPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                keypadInput("0");
                wrongAnswer.SetActive(false);// in case wrong answer is displayed. on click dont show wrong answer

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
                if (laptop_myNumber.text == currentAnswer)
                {
                    Laptop_OpenPanel.SetActive(false);
                    Laptop_OpenPanel = null;
                    correct = true;
                    _animator.SetBool("Laptop_on", false);
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
        }

    }

    //show the the password panel for some seconds and then deactivate and set the mini password panel to true
    IEnumerator ShowSuccess()
    {
        Reward_OpenPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        Reward_OpenPanel.SetActive(false);
        passwordShownMinimalized.SetActive(true);
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
            if (laptop_myNumber.text == currentAnswer)
            {

                Laptop_OpenPanel.SetActive(false);
                Laptop_OpenPanel = null;
                correct = true;
                _animator.SetBool("Laptop_on", false);
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
            Reward_OpenPanel.SetActive(true);
            
        }
        if (correct && Laptop_isInsideTrigger == false)
        {
            Reward_OpenPanel.SetActive(false);
            passwordShownMinimalized.SetActive(true); 
        }

    }
}
