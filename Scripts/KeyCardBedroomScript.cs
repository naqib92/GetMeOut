using UnityEngine;
using System.Collections;

public class KeyCardBedroomScript : MonoBehaviour {

    public bool inTrigger;
    public GameObject OpenPanel = null;
    public GameObject shownMinimizedKeycard = null;
    public Camera fpsCam;

    public string OpenText = "Take key card";
    public string CloseText = "";

    private bool _isOpen = false;





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

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Keycard_Bedroom")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);// panel can now being seen

            }


        }
        else
        {
            OpenPanel.SetActive(false);// panel is invincible
            inTrigger = false;

        }




        // when panel is visible show text 
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DoorBedroomScript.keyCardBedroom = true;
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);// panel is invincible
                shownMinimizedKeycard.SetActive(true);
            }
        }
    
    }
}
