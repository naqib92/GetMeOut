using UnityEngine;
using System.Collections;

public class Take_OutsideItemsScript : MonoBehaviour {

    public GameObject OpenPanel = null;
    public GameObject displayItem;
    public GameObject showpassword_Panel;
    public Camera fpsCam;
    private PlayerStatusScript giveHealth;


    public string OpenText = "Take item";
    public string CloseText = "";
    private bool _isOpen = false;

    private bool inTrigger;
    private bool inTrigger1;
    private bool inTrigger2;
    private bool inTrigger3;
    private bool inTrigger4;

    private float health = 0.10f;


    void Start()
    {
        giveHealth = GetComponent<PlayerStatusScript>();
    }

    // for checking if the health cross panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the health cross panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }


    // if raycast hits the health cross collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            //health cross 0
            if (hit.collider.gameObject.tag == "take_Health")
            {
                inTrigger = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);

            }
            //health cross 1
            if (hit.collider.gameObject.tag == "take_Health(1)")
            {
                inTrigger1 = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }
            //health cross 2
            if (hit.collider.gameObject.tag == "take_Health(2)")
            {
                inTrigger2 = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }
            //health cross 3
            if (hit.collider.gameObject.tag == "take_Health(3)")
            {
                inTrigger3 = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }
            //health cross 4
            if (hit.collider.gameObject.tag == "take_PaperOutside")
            {
                inTrigger4 = true;
                UpdatePanelText();
                OpenPanel.SetActive(true);
            }


        }
        else
        {
           OpenPanel.SetActive(false);
           inTrigger = false;
           inTrigger1 = false;
           inTrigger2 = false;
           inTrigger3 = false;
           inTrigger4 = false;

        }

    }



    // if _isInsideTrigger is true and mouse is pressed destroy object and increase health 
    void InsideTrigger()
    {   
        //health cross 0
        if (inTrigger)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                giveHealth.IncreaseHealth(health);// increase health
                Destroy(GameObject.FindWithTag("take_Health"));// destroy cross health item
                OpenPanel.SetActive(false);// panel is invincible
                inTrigger = false;
            }
        }
        //health cross 1
        if (inTrigger1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                giveHealth.IncreaseHealth(health);// increase health
                Destroy(GameObject.FindWithTag("take_Health(1)"));// destroy cross health item
                OpenPanel.SetActive(false);// panel is invincible
               inTrigger1 = false;
            }
        }
        //health cross 2
        if (inTrigger2)
        {
            if (Input.GetMouseButtonDown(1))
            {
                giveHealth.IncreaseHealth(health);// increase health
                Destroy(GameObject.FindWithTag("take_Health(2)"));// destroy cross health item
                OpenPanel.SetActive(false);// panel is invincible
                inTrigger2 = false;
            }
        }
        //health cross 3
        if (inTrigger3)
        {
            if (Input.GetMouseButtonDown(1))
            {
                giveHealth.IncreaseHealth(health);// increase health
                Destroy(GameObject.FindWithTag("take_Health(3)"));// destroy cross health item
                OpenPanel.SetActive(false);// panel is invincible
                inTrigger3 = false;
            }
        }
        //health cross 3
        if (inTrigger4)
        {
            if (Input.GetMouseButtonDown(1))
            {
                showpassword_Panel.SetActive(true);
                Destroy(GameObject.FindWithTag("take_PaperOutside"));// destroy paper item
                OpenPanel.SetActive(false);// panel is invincible
                inTrigger4 = false;
            }
        }
    }


    void Update()
    {
            _RaycastHit();
             InsideTrigger();
    }
}
