using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionButtonsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _modeSelectionPanel;

    public void TimeModeButtonOnClick()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void StoryModeButtonOnClick()
    {
        // запуск сюжетной линии
    }

    public void BackToMainMenuButtonOnClick()
    {
        _modeSelectionPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
