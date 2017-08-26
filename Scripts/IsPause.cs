using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class IsPause : MonoBehaviour
{

    public GameObject continueGaming;
    public GameObject options_Panel;
    public GameObject onPause_Panel;
    public GameObject isDead_Panel;
    public UnityEngine.UI.Image pauseBackground;
    public Transform Player;

    public static bool escape_buttonsEnabled = true;

    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    public void ContinueGame()
    {
        pauseBackground.gameObject.SetActive(false); //close the background image
        onPause_Panel.SetActive(false); // close the pause panel
        Time.timeScale = 1;     //allow movements around the enviroment
        Player.GetComponent<FirstPersonController>().enabled = true;// allow player movement
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void GameSettings()
    {
        options_Panel.SetActive(true);  //open the settings panel
        onPause_Panel.SetActive(false); //close the pause panel
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {

        if (escape_buttonsEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // if pause panel and option panel are not opened and the escape key is pressed
                // then open the pause panel
                if (onPause_Panel.gameObject.activeInHierarchy == false && options_Panel.gameObject.activeInHierarchy == false)
                {
                    onPause_Panel.gameObject.SetActive(true);// show the option panel
                    pauseBackground.gameObject.SetActive(true);
                    Time.timeScale = 0; //stop every movement around the enviroment
                    Player.GetComponent<FirstPersonController>().enabled = false; //stop the player from moving
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true; // show cursor
                }
                //else if the pause panel and the option panel are opened and the escape key is pressed
                //then close the pause panel
                else
                {
                    pauseBackground.gameObject.SetActive(false); //close the background image
                    onPause_Panel.SetActive(false); // close the pause panel
                    Time.timeScale = 1;     //allow movements around the enviroment
                    Player.GetComponent<FirstPersonController>().enabled = true;// allow player movement
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }


                // if the option panel is opended and the pause panel is closed and the escape key is pressed
                //then close the option panel
                if (options_Panel.gameObject.activeInHierarchy == true && onPause_Panel.gameObject.activeInHierarchy == false)
                {
                    options_Panel.SetActive(false);
                    onPause_Panel.gameObject.SetActive(false);
                    pauseBackground.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

        }
    }
}
