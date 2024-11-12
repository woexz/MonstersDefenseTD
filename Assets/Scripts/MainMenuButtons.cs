using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void StartGameButtonOnClick()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
