using UnityEngine;
using System.Collections;

public class WeaponInSafeScript : MonoBehaviour
{

    public Animator _animator;
    public GameObject openPanel = null;
    public GameObject outsideDoorIsOpened_Panel;
    public GameObject weapon;
   // public GameObject weaponInSafe;
    public GameObject crosshair;
    public GameObject weaponIcon;
    public Camera fpsCam;
    public string openText = "Take item";
    public string closeText = "";
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
            return openPanel.activeInHierarchy;
        }
    }


    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = openPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? closeText : openText;//if _isOpen is true return CloseText or else return openText
        }
    }

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "weaponInSafe")
            {
                inTrigger = true;
                UpdatePanelText();
                openPanel.SetActive(true);// panel can now being seen
            }


        }
        else
        {
            openPanel.SetActive(false);// panel is invincible
            inTrigger = false;
        }


        // when panel is visible show text 
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DoorOutsideScript.weaponObtained = true;
                Destroy(this.gameObject);// destroy the gameobject that the script refers to
                //weaponInSafe.SetActive(false);
                openPanel.SetActive(false);// panel is invincible
                outsideDoorIsOpened_Panel.SetActive(true);// "outside door is now opened"
                weapon.SetActive(true);// display weapon
                weaponIcon.SetActive(true);// display weaponIcon
                crosshair.SetActive(true);
                EnemyAIScript.isOutside = true;
            }
        }

    }
}
