using UnityEngine;
using System.Collections;

public class MicrowaveScript : MonoBehaviour {


    public Animator _animator;
    public GameObject OpenPanel = null;

    public Collider MicrowaveCollider;
    public Camera fpsCam;

    private bool _isInsideTrigger = false;

    public string OpenText = "Press the left mouse button to open slider";
    public string CloseText = "Press the left mouse button to close slider";

    private bool _isOpen = false;
    




    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
    
}






    // for checking if the microwave panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the microwave panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the microwave door collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "door_Microwave")
            {
                _isInsideTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }


        }
        else
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
        }

    }
    //if microwave panel is active, _isInsideTrigger is true and mouse is pressed then open the microwave door
    void InsideTrigger()
    {
        // when panel is visible show text 
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //  _isOpen = !_isOpen;

                // UpdatePanelText();

                _animator.SetBool("open_Microwave", true);
                OpenPanel.SetActive(false);
                MicrowaveCollider.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update ()
    {

        _RaycastHit();
        InsideTrigger();

    }
}
