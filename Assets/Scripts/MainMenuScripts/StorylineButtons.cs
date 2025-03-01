using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorylineButtons : MonoBehaviour
{
    [SerializeField] private GameObject _storylineButtonsPanel;
    [SerializeField] private GameObject _modeSelectionButtonsPanel;
    [SerializeField] private GameObject _savesPanel;
    [SerializeField] private GameObject _background;

    [SerializeField] private ListOfSavesSO _listOfSavesSO;
    [SerializeField]

    public void StartNewGameOnClick()
    {
        SceneManager.LoadScene("Storyline1");
    }

    public void LoadSaveOnClick()
    {
        _storylineButtonsPanel.SetActive(false);
        _savesPanel.SetActive(true);
        _background.SetActive(false);
        //foreach (var save in _listOfSavesSO.listOfSaves)
        //{
        //    Debug.Log(save);
        //}
    }

    public void BackToModeSelectionOnClick()
    {
        _storylineButtonsPanel.SetActive(false);
        _modeSelectionButtonsPanel.SetActive(true);     
    }
}
