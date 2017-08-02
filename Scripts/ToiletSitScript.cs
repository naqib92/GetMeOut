using UnityEngine;
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


    // for checking if the toilet lid panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the toilet lid panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the toiletsit collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "ToiletSit")
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
    //if _isInsideTrigger is true and mouse is pressed open toilet lid
    void InsideTrigger()
    {
   
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

    // Update is called once per frame
    void Update()
    {

        _RaycastHit();
        InsideTrigger();



    }
}
