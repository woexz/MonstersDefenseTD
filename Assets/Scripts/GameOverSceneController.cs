using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    public void TryAgainOnClick()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void BackToMainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
