using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneController : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerDataSO; 

    public void BackToMainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
        _playerDataSO.ChosenGameManager = null;
    }

    public void GoToNextLevelOnClick()
    {
        SceneManager.LoadScene("Storyline" + Convert.ToString(_playerDataSO.currentLevel));
    }

    public void PlayAgainOnClick()
    {
        Debug.LogError(_playerDataSO.ChosenGameManager);
        SceneManager.LoadScene("TimeMode");
    }

    public void SaveProgressOnClick()
    {
        PlayerDataToSave playerDataToSave = new PlayerDataToSave();
        playerDataToSave.mana = _playerDataSO.mana;
        playerDataToSave.currentCastleHealth = _playerDataSO.currentCastleHealth;
        playerDataToSave.maxCastleHealth = _playerDataSO.maxCastleHealth;
        playerDataToSave.currentLevel = 1; //заглушка, изменить


        SaveProgressJsonManager.Instance.AddNewRecords(playerDataToSave);
        SaveProgressJsonManager.Instance.SaveScoreRecords();
        Debug.Log("ѕрогресс успешно сохранен");
    }
}
