using UnityEngine;
using System.Collections;

public class KeyCardBedroomScript : MonoBehaviour {


    public GameObject openPanel = null;
    public GameObject shownMinimizedKeycard = null;
    public Camera fpsCam;



    public string openText = "Take key card";
    public string closeText = "";
    public bool inTrigger;
    private bool _isOpen = false;

   

    // for checking if the key card panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return openPanel.activeInHierarchy;
        }
    }

    // for updating the key card panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = openPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? closeText : openText;//if _isOpen is true return closeText or else return openText
        }
    }


    // if raycast hits the key card collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Keycard_Bedroom")
            {
                inTrigger = true;
                UpdatePanelText();
                openPanel.SetActive(true);

            }


        }
        else
        {
            openPanel.SetActive(false);
            inTrigger = false;

        }

    }



    // if _isInsideTrigger is true and mouse is pressed destroy key card and display "key card obtained" 
    void InsideTrigger()
    {
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DoorBedroomScript.keyCardBedroom = true;
                Destroy(GameObject.FindWithTag("Keycard_Bedroom"));
                openPanel.SetActive(false);// panel is invincible
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
