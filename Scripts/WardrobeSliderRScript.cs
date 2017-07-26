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
        if(panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }

    public IEnumerator openSlider()
    {
        yield return new WaitForSeconds(0.3f);
        Keycard_Bedroom.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "WardrobeSliderR")
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

               // UpdatePanelText();

                _animator.SetBool("open_WardrobeSliderR", true);
                OpenPanel.SetActive(false);
                StartCoroutine(openSlider());
                WadrobeCollider.enabled = false;


            }
        }
   
    }
}



