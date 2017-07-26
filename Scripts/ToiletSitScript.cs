﻿using UnityEngine;
using System.Collections;

public class ToiletSitScript : MonoBehaviour {


    public Animator _animator;
    public GameObject OpenPanel = null;
    public Collider ToiletSitCollider;
    public GameObject Keycard_Toilet;
    public Camera fpsCam;

    private bool _isInsideTrigger = false;

    public string OpenText = "Open toilet seat";
    public string CloseText = "";

    private bool _isOpen = false;
 


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
            if (hit.collider.gameObject.tag == "ToiletSit")
            {
                _isInsideTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);// panel can now being seen
            }


        }
        else
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);// panel is invincible
        }


        // when panel is visible show text 
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                
               // _isOpen = !_isOpen;

                //UpdatePanelText();
                _animator.SetBool("open_ToiletSeat", true);
                Keycard_Toilet.SetActive(true);
                ToiletSitCollider.enabled = false;

            }
        }

    }
}
