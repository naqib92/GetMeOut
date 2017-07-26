using UnityEngine;
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
            if (hit.collider.gameObject.tag == "door_Bathroom" || hit.collider.gameObject.tag == "slot_Bathroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);// panel can now being seen
                _animator.SetBool("BathroomSlot_showError", true);
            }


        }
        else
        {
            inTrigger = false;
            OpenPanel.SetActive(false);// panel is invincible
            _animator.SetBool("BathroomSlot_showError", false);
        }


        destroyKeycardMinimalized002 = GameObject.FindGameObjectWithTag("keycard002");

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
        if (_animator.GetBool("OpenDoorBathroom") == true)
        {
            Destroy(destroyKeycardMinimalized002);
        }
    }
}