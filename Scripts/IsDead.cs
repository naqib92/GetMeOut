﻿using UnityEngine;
using System.Diagnostics;

public class IsDead : MonoBehaviour {

      public Transform Player;
      public UnityEngine.UI.Image bar;

    public void RestartGame()
    {
        FindObjectOfType<SFX_Manager>().Play("buttonSound");
        Process.Start(Application.dataPath + "/../tryx86_64.exe");
        Application.Quit();
    }

    public void ExitGame()
    {
        FindObjectOfType<SFX_Manager>().Play("buttonSound");
        Application.Quit();
    }
}
