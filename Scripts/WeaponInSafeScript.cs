using UnityEngine;
using System.Collections;

public class WeaponInSafeScript : MonoBehaviour {

    public Animator _animator;   
    public GameObject OpenPanel = null;
    public GameObject OutsideDoorIsOpened_Panel;
    public GameObject Weapon;
    public GameObject Crosshair;
    public GameObject WeaponIcon;
    public Camera fpsCam;
    public string OpenText = "Take item";
    public string CloseText = "";
    public bool inTrigger;
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
            if (hit.collider.gameObject.tag == "weaponInSafe" )
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
                DoorOutsideScript.weaponObtained = true;
                Destroy(this.gameObject);// destroy the gameobject that the script refers to
                OpenPanel.SetActive(false);// panel is invincible
                OutsideDoorIsOpened_Panel.SetActive(true);// "outside door is now opened"
                Weapon.SetActive(true);// display weapon
                WeaponIcon.SetActive(true);// display weaponIcon
                Crosshair.SetActive(true);
            }
        }

    }
}
