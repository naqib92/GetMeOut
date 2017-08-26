using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Diagnostics;

public class IsDead : MonoBehaviour {

      public Transform Player;
      public UnityEngine.UI.Image bar;

    public void RestartGame()
    {
        Process.Start(Application.dataPath + "/../tryx86_64.exe");
        Application.Quit();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
