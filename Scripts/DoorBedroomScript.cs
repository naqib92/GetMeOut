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


    // for checking if the bedroom door panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the bedroom door panel text 
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the bedroom door collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "door_Bedroom" || hit.collider.gameObject.tag == "slot_Bedroom")
            {
                _animator.SetBool("BedroomSlot_showError", true);
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }


        }
        else
        {
            _animator.SetBool("BedroomSlot_showError", false);
            inTrigger = false;
            OpenPanel.SetActive(false);
        }

    }
    //if _isInsideTrigger is true and mouse is pressed open bedroom door, show no error and deactivate the bedroom door panel
    void InsideTrigger()
    {
        if (inTrigger == true)
        {

            if (keyCardBedroom)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetBool("BedroomSlot_showNoError", true);
                    _animator.SetBool("OpenDoorBedroom", true);
                    OpenPanel.SetActive(false);
                    OpenPanel = null;

                }


            }
        }

    }

    // destroy the mini panel "keycard obtainded" when doors opens
    void DestroyPanel()
    {
        destroyKeycardMinimalized001 = GameObject.FindGameObjectWithTag("keycard001");
        if (_animator.GetBool("OpenDoorBedroom") == true)
        {
            Destroy(destroyKeycardMinimalized001);
        }
    }


    // Update is called once per frame
    void Update()
    {

        _RaycastHit();
        InsideTrigger();
        DestroyPanel();

    }
}