﻿using UnityEngine;
using System.Collections;

public class DoorBathroomScript : MonoBehaviour {

    public Animator _animator;
    public GameObject OpenPanel = null;
    public GameObject destroyKeycardMinimalized002;// for destroying the panel keycard obtainded
    public Camera fpsCam;

    public bool inTrigger;

    public string OpenText = "Insert KeyCard to Open door";
    public string CloseText = "";

    private bool _isOpen = false;

    public static bool keyCard_To_Bathroom;


    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();


    }

    // for checking if the bathroom door panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the bathroom door panel text 
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the bathroom door collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "door_Bathroom" || hit.collider.gameObject.tag == "slot_Bathroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
                _animator.SetBool("BathroomSlot_showError", true);
            }


        }
        else
        {
            inTrigger = false;
            OpenPanel.SetActive(false);
            _animator.SetBool("BathroomSlot_showError", false);
        }
    }


    //if _isInsideTrigger is true and mouse is pressed show no error, open bathroom door and deactivate the bathroom door panel
    void InsideTrigger()
    {
        if (inTrigger == true)
        {
            if (keyCard_To_Bathroom)
            // if (true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetBool("OpenDoorBathroom", true);
                    OpenPanel.SetActive(false);// panel is invincible
                    _animator.SetBool("BathroomSlot_showNoError", true);
                    OpenPanel = null;

                }


            }

        }
    }
    // destroy the mini panel "keycard obtainded" when door opens
    void DestroyPanel()
    {
        destroyKeycardMinimalized002 = GameObject.FindGameObjectWithTag("keycard002");


        if (_animator.GetBool("OpenDoorBathroom") == true)
        {
            Destroy(destroyKeycardMinimalized002);
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