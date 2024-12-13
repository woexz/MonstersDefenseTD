using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesButtonsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _storylineButtonsPanel;
    [SerializeField] private GameObject _savesPanel;
    [SerializeField] private GameObject _background;

    public void BackButtonOnClick()
    {
        _savesPanel.SetActive(false);
        _storylineButtonsPanel.SetActive(true);
        _background.SetActive(true);
    }
}
