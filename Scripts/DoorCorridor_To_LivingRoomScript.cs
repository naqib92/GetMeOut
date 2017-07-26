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
            if (hit.collider.gameObject.tag == "door_Livingroom" || hit.collider.gameObject.tag == "slot_Livingroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);// panel can now being seen
            }


        }
        else
        {
            inTrigger = false;
            OpenPanel.SetActive(false);// panel is invincible
        }



        if (inTrigger == true)
        {

                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetBool("open_CorToLivDoor", true);
                    OpenPanel.SetActive(false);// panel is invincible
                    
                    OpenPanel = null;
                }
            
        }
    }
}
