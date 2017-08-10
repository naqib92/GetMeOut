using UnityEngine;
using System.Collections;

public class Item_EyeForMiniMap : MonoBehaviour {
    public GameObject OpenPanel = null;
    public Camera fpsCam;
    public GameObject miniMapCam;

    public bool inTrigger;
    public string OpenText = "Take Item";
    public string CloseText = "";
    private bool _isOpen = false;


    // Use this for initialization
    void Start () {
        

    }



    // for checking if the item panel is activ
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // for updating the item panel text
    private void UpdatePanelText()
    {
        UnityEngine.UI.Text panelText = OpenPanel.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;//if _isOpen is true return CloseText or else return openText
        }
    }

    // if raycast hits the item collider, set _isInsideTrigger to true else set to false
    void _RaycastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "item_Eye")
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



    // if _isInsideTrigger is true and mouse is pressed destroy item and display "item obtained" 
    void InsideTrigger()
    {
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                miniMapCam.SetActive(true);
                Destroy(this.gameObject);
                OpenPanel.SetActive(false);
            }
        }

    }
    // Update is called once per frame
    void Update ()
    {
        _RaycastHit();
        InsideTrigger();



    }
}
