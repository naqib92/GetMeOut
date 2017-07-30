using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrawerOpenScript : MonoBehaviour
{

    public Animator _animator;
    public GameObject Paper;//paper.png
    public GameObject Panel_Chestdrawer = null;
    public GameObject OpenPanel_ToReadPaper;


    private bool _isInsideTrigger = false;
    public string OpenText = "open drawer";
    public string CloseText = "";

    private bool _isOpen = false;

    private float time;//timer for letting paper appear after 0.7 sec after drawer has been opened




    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        Paper.SetActive(false);
        time = Time.time;

    }

    //collision with the box collider
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            UpdatePanelText();
            Panel_Chestdrawer.SetActive(true);// panel can now being seen

        }

    }

    //movement out of the box collider
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            Panel_Chestdrawer.SetActive(false);// panel is invincible
            OpenPanel_ToReadPaper.SetActive(false);
        }
    }

    // for checking if the drawer panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return Panel_Chestdrawer.activeInHierarchy;
        }
    }

    // for updating the drawer panel text 
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = Panel_Chestdrawer.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }

    // Update is called once per frame
    void Update()
    {




        // if panel is activ and if _isInsideTrigger is true
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _isOpen = !_isOpen;

                UpdatePanelText();

                _animator.SetBool("open", _isOpen);
            }
        }
        if (_animator.GetBool("open") == true)
        {
                 if (Time.time >= time + 0.7f)// time starts running when the drawer is opened. if time reaches 0.7sec then do the code under
                 {
          
                OpenPanel_ToReadPaper.SetActive(true);
                Paper.SetActive(true);
                
                }
        }
        else// if panel is not opened put time to 0
        {
            OpenPanel_ToReadPaper.SetActive(false);
            Paper.SetActive(false);
            time = Time.time;

        }
        if (_isInsideTrigger == false)
        {
            OpenPanel_ToReadPaper.SetActive(false);
        }
    }


}
