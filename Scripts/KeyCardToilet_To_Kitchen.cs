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


    // if raycast hits the key card collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "keycard_Toilet")
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

        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {

                DoorKitchenScript.KeyCard_To_Laptop = true;// set to true so the kitchen door shows "go do activation to open" 
                Laptop_GameScript_2.KeyCard_To_Laptop = true;// set to true so player can play the second game

                Laptop_GameScript.putOffPanel_Game1 = true;// in case first game wasnt played then dont show the panel
                //Laptop_GameScript_2.putLaptopOn = true;
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);// panel is invincible
                shownMinimizedKeycard003.SetActive(true);
            }
        }

    }
    void Update()
    {
        _RaycastHit();
        InsideTrigger();

    }
}
