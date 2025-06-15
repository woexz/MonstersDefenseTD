using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _modeSelectionPanel;

    [SerializeField] private GameObject _gameName;
    [SerializeField] private GameObject _modeImage;

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void PlayGameButtonOnClick()
    {
        _gameName.SetActive(false);
        _mainMenuPanel.SetActive(false);
        _modeImage.SetActive(true);
        _modeSelectionPanel.SetActive(true);
    }
}
