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
    }

    public void PlayAgainOnClick()
    {
        SceneManager.LoadScene("TimeMode");
    }

    public void SaveProgressOnClick()
    {
        PlayerDataToSave playerDataToSave = new PlayerDataToSave();
        playerDataToSave.mana = _playerDataSO.mana;
        playerDataToSave.currentCastleHealth = _playerDataSO.currentCastleHealth;
        playerDataToSave.maxCastleHealth = _playerDataSO.maxCastleHealth;
        playerDataToSave.currentLevel = "выбранный уровень";


        SaveProgressJsonManager.Instance.AddNewRecords(playerDataToSave);
        SaveProgressJsonManager.Instance.SaveScoreRecords();
        Debug.Log("ѕрогресс успешно сохранен");
    }
}
