using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionButtonsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _modeSelectionPanel;
    [SerializeField] private GameObject _storylineButtonsPanel;

    [SerializeField] private PlayerDataSO _playerData;

    public void TimeModeButtonOnClick()
    {
        _playerData.chosenGameManager = FindObjectOfType<TimeModeManager>();
        SceneManager.LoadScene("TimeMode");
    }

    public void StoryModeButtonOnClick()
    {
        _playerData.chosenGameManager = FindObjectOfType<StorylineGameManager>();
        _modeSelectionPanel.SetActive(false);
        _storylineButtonsPanel.SetActive(true);
    }

    public void BackToMainMenuButtonOnClick()
    {
        _modeSelectionPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
