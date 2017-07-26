using UnityEngine;
using System.Collections;

public class DoorOutsideDeactivatePanel : MonoBehaviour {

    public GameObject OutsideDoorIsOpened;
    //collision with the box collider
    void OnTriggerEnter(Collider other)
    {
        OutsideDoorIsOpened.SetActive(false); // deactivates the panel "door to go outside is opened" which was activated in weaponScript.cs => OutsideDoorIsOpened.SetActive(true);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
