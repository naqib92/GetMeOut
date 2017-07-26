using UnityEngine;
using System.Collections;

public class KeyCardToilet_To_Kitchen : MonoBehaviour {


    
    public GameObject OpenPanel = null;
    public GameObject shownMinimizedKeycard003;
    public Camera fpsCam;

    public string OpenText = "Take key card";
    public string CloseText = "";

    private bool _isOpen = false;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        UpdatePanelText();
        OpenPanel.SetActive(true);// panel can now being seen
    }

    void OnTriggerExit(Collider other)
    {
        OpenPanel.SetActive(false);// panel is invincible
        inTrigger = false;
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

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "keycard_Toilet")
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
                
                DoorKitchenScript.KeyCard_To_Laptop = true;
                Laptop_GameScript_2.KeyCard_To_Laptop = true;

                Laptop_GameScript.putOffPanel_Game1 = true;// in case first game wasnt played then dont show the panel
                //Laptop_GameScript_2.putLaptopOn = true;
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);// panel is invincible
                shownMinimizedKeycard003.SetActive(true);
            }
        }

    }
}
