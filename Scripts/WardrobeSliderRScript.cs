using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeSliderRScript : MonoBehaviour
{

    public Animator _animator;
    public GameObject OpenPanel = null;
    public GameObject Keycard_Bedroom;
    public Collider WadrobeCollider;
    public Camera fpsCam;

    private bool _isInsideTrigger = false;

    public string OpenText = "Press the left mouse button to open slider";
    public string CloseText = "Press the left mouse button to close slider";

    private bool _isOpen = false;



    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
 
    }

    // for checking if the wardrobeslider panel is activ
        private bool IsOpenPanelActive
        {
            get
            {
                return OpenPanel.activeInHierarchy;
            }
        }

    // for updating the wardrobeslider panel text    
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if(panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }

    IEnumerator OpenSlider()
    {
        yield return new WaitForSeconds(0.3f);
        Keycard_Bedroom.SetActive(true);
    }

    // if raycast hits the wardrobeslider collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "WardrobeSliderR")
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

    void InsideTrigger()
    {
        // if the wardrobeslider panel is activ and if _isInsideTrigger is true
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                // _isOpen = !_isOpen;

                // UpdatePanelText();

                _animator.SetBool("open_WardrobeSliderR", true);
                OpenPanel.SetActive(false);
                StartCoroutine(OpenSlider());
                WadrobeCollider.enabled = false;


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



