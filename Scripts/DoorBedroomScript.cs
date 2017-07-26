using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorBedroomScript : MonoBehaviour
{

    public Animator _animator;
    public GameObject OpenPanel = null;
    public GameObject destroyKeycardMinimalized001;// important! using Tag to destroy // for destroying the panel keycard obtainded
    public Camera fpsCam;

    public bool inTrigger;

    public string OpenText = "Insert KeyCard to Open door";
    public string CloseText = "";

    private bool _isOpen = false;

    public static bool keyCardBedroom;


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
                if (hit.collider.gameObject.tag == "door_Bedroom" || hit.collider.gameObject.tag == "slot_Bedroom")
                {
                    _animator.SetBool("BedroomSlot_showError", true);
                    inTrigger = true;
                    UpdatePanelText();
                    OpenPanel.SetActive(true);// panel can now being seen
                }


            }
            else
            {
                _animator.SetBool("BedroomSlot_showError", false);
                inTrigger = false;
                OpenPanel.SetActive(false);// panel is invincible
            }



            destroyKeycardMinimalized001 = GameObject.FindGameObjectWithTag("keycard001");

        if (inTrigger == true)
        {

            if (keyCardBedroom)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetBool("BedroomSlot_showNoError", true);
                    _animator.SetBool("OpenDoorBedroom", true);
                    OpenPanel.SetActive(false);// panel is invincible
                    OpenPanel = null;

                }


            }
        }
        
        if (_animator.GetBool("OpenDoorBedroom") == true)
        {
            Destroy(destroyKeycardMinimalized001);
        }
    }
}