using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Gamescene");
    }

    public void restartgame()
    {
        SceneManager.LoadScene("Menuscene");
    }
}
