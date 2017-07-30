using UnityEngine;
using System.Collections;

public class KeyCardLivingroomScript : MonoBehaviour
{

    public bool inTrigger;
    public GameObject OpenPanel = null;
    public GameObject shownMinimizedKeycard;
    public Camera fpsCam;

    public string OpenText = "Take key card";
    public string CloseText = "";

    private bool _isOpen = false;


    // for checking if the key card panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the key card panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }
    // if raycast hits the key card collider, set _isInsideTrigger to true else set to fals
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "keycard_Livingroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }


        }
        else
        {
            OpenPanel.SetActive(false);
            inTrigger = false;
        }

    }
    //if _isInsideTrigger is true and mouse is pressed destroy key card and display "key card obtained" 
    void InsideTrigger()
    {
        // when panel is visible show text 
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DoorBathroomScript.keyCard_To_Bathroom = true;
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);
                shownMinimizedKeycard.SetActive(true);
            }
        }

    }
    void Update()
    {

        _RaycastHit();
        InsideTrigger();

    }
}