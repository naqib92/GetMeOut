using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public Image blackFadeInOUtImage;//used for fading in
    public Animator anim;// used for fading in


    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame(string newGame)
    {       
        StartCoroutine(LoadAsynchronously1(newGame));        
        //SceneManager.LoadScene(newGame);
    }

    public void GameSettings(string settings)
    {
        StartCoroutine(LoadAsynchronously2(settings));
        //SceneManager.LoadScene(settings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    IEnumerator LoadAsynchronously2(string settings)
    {
        //change scene and load the bar
        AsyncOperation operation = SceneManager.LoadSceneAsync(settings);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
            slider.value = progress;
            progressText.text = (Mathf.RoundToInt(progress)) * 100f + "%";
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously1(string newGame)
    {
        //change scene and load the bar
        AsyncOperation operation = SceneManager.LoadSceneAsync(newGame);

        loadingScreen.SetActive(true);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
            slider.value = progress;
            progressText.text = (Mathf.RoundToInt(progress)) * 100f + "%";
            yield return null;
        }

    }
}
