using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _modeSelectionPanel;

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void PlayGameButtonOnClick()
    {
        _mainMenuPanel.SetActive(false);
        _modeSelectionPanel.SetActive(true);
    }
}
