using UnityEngine;
using System.Collections;

public class DoorCorridor_To_LivingRoomScript : MonoBehaviour {

    public Animator _animator;
    public GameObject OpenPanel = null;
    public Camera fpsCam;

    public bool inTrigger;

    public string OpenText = "Left mouse to Open door";
    public string CloseText = "";

    private bool _isOpen = false;

    public static bool keyCardBedroom;


    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // for checking if the livingroom door panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the livingroom panel text 
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the livingroom collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "door_Livingroom" || hit.collider.gameObject.tag == "slot_Livingroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }


        }
        else
        {
            inTrigger = false;
            OpenPanel.SetActive(false);
        }


    }

    //if _isInsideTrigger is true and mouse is pressed, open livingroom door deactiviate the livingroom door panel
    void InsideTrigger()
    {
        if (inTrigger == true)
        {

            if (Input.GetMouseButtonDown(1))
            {
                _animator.SetBool("open_CorToLivDoor", true);
                OpenPanel.SetActive(false);

                OpenPanel = null;
            }

        }

    }


    // Update is called once per frame
    void Update()
    {
        _RaycastHit();
        InsideTrigger();
    }
}
