using UnityEngine;
using System.Collections;

public class DoorOutsideScript : MonoBehaviour {

    public Animator _animator;
    public GameObject OpenPanel = null;
    public Camera fpsCam;

    public bool inTrigger;

    public string OpenText = "access denied";
    public string CloseText = "";

    private bool _isOpen = false;
    public static bool weaponObtained = false;

    // Use this for initialization
    void Start () {
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
            if (hit.collider.gameObject.tag == "door_Outside" || hit.collider.gameObject.tag == "slot_Outside")
            {
                            if (weaponObtained == true)
                            {
                                //do nothing
                            }
                            else
                            {
                                inTrigger = true;
                                UpdatePanelText();
                                OpenPanel.SetActive(true);// panel can now being seen
                                _animator.SetBool("OutsideSlot_showError", true);
                            }
            }


        }
        else
        {
                            if (weaponObtained == true)
                            {
                                //do nothing
                            }
                            else
                            {
                                inTrigger = false;
                                OpenPanel.SetActive(false);// panel is invincible
                                _animator.SetBool("OutsideSlot_showError", false);
                            }
        }

        if (inTrigger == true)
        {
                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetBool("open_OutsideDoor", false);
                   // OpenPanel.SetActive(false);// panel is invincible
                    //OpenPanel = null;
                }
            
        }
        if (weaponObtained == true)
        {
            _animator.SetBool("OutsideSlot_showError", true);
            _animator.SetBool("OutsideSlot_showNoError", true);
            _animator.SetBool("open_OutsideDoor", true);
        }

    }
}
