using UnityEngine;
using System.Collections;

public class KeyCardKitchen_To_Weapon : MonoBehaviour {

    
    public GameObject OpenPanel = null;
    public GameObject shownMinimizedKeycard004;
    public Camera fpsCam;
    public string OpenText = "Take key card";
    public string CloseText = "";

    private bool _isOpen = false;
    public bool inTrigger;



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


    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "keycard_Kitchen")
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
                //DoorBedroomScript.keyCardBedroom = true;
                Laptop_GameScript_3.KeyCard_To_Laptop = true;
                WeaponSafe_CorridorScript.KeyCard_To_Laptop = true;

                Laptop_GameScript_2.putOffPanel_Game2 = true;// in case second game wasnt played then dont show the panel
                Laptop_GameScript.putOffPanel_Game1 = true;// in case first game wasnt played then dont show the panel
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);// panel is invincible
                shownMinimizedKeycard004.SetActive(true);
            }
        }
    }
}
