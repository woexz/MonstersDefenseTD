using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;

    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("SceneController").AddComponent<SceneController>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("TimeMode");
    }

    public void TryAgainOnClick()
    {
        SceneManager.LoadScene("TimeMode");
    }

    public void BackToMainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
