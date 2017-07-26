using UnityEngine;
using System.Collections;

public class DoorKitchenScript : MonoBehaviour {

    public Animator _animator;
    public GameObject OpenPanel = null;
 
    public GameObject OpenPanel_go_Do_Activation = null;

    public GameObject destroyKeycardMinimalized003;// important! using Tag to destroy
    public GameObject destroyKeycardIsActiveMinimalized003;// important! using Tag to destroy
    public Camera fpsCam;

    public bool inTrigger;

    public string OpenText = "Insert KeyCard to Open door";
    public string CloseText = "";

    private bool _isOpen = false;



    public static bool KeyCard_To_Laptop; // key card is now activ for the door to open from Laptop_GameScript2.cs => DoorKitchenScript.keycardIsActiv = true
    public static bool keycardIsActiv;// dont show key needs to be activated since the answer is correct from Laptop_GameScript3.cs => DoorKitchenScript.KeyCard_To_Laptop = false

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();


    }



    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }


    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "door_Kitchen" || hit.collider.gameObject.tag == "slot_Kitchen")
            {
                inTrigger = true;
                UpdatePanelText();
                _animator.SetBool("KitchenSlot_showError", true);

                if (KeyCard_To_Laptop == true)//if key card is set to true from Laptop_GameScript2.KeyCard_To_Laptop
                {
                    OpenPanel_go_Do_Activation.SetActive(true);

                }
                else
                {
                    OpenPanel.SetActive(true);// panel can now being seen

                }
            }


        }
        else
        {
            inTrigger = false;
            _animator.SetBool("KitchenSlot_showError", false);

            if (KeyCard_To_Laptop == true)
            {
                OpenPanel_go_Do_Activation.SetActive(false);
            }
            else
            {
                OpenPanel.SetActive(false);// panel is invincible
            }
        }

        destroyKeycardMinimalized003 = GameObject.FindGameObjectWithTag("keycard003");
        destroyKeycardIsActiveMinimalized003 = GameObject.FindGameObjectWithTag("keycardIsActive03");

        if (inTrigger == true)
        {
          
                if (Input.GetMouseButtonDown(1))
                {

                    if(keycardIsActiv == true)
                    {
                    _animator.SetBool("openKitchenDoor", true);
                    OpenPanel.SetActive(false);// panel is invincible
                    _animator.SetBool("KitchenSlot_showNoError", true);
                    OpenPanel = null;
                    Laptop_GameScript_2.KeyCard_To_Laptop = false;// dont show the game on the laptop
                }
                    
                }


            

        }
        if (_animator.GetBool("openKitchenDoor") == true)
        {
            Destroy(destroyKeycardMinimalized003);
            Destroy(destroyKeycardIsActiveMinimalized003);
        }
    }
}
