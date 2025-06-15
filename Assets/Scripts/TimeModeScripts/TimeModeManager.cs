using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeModeManager : AbstractLevelManager
{
    [SerializeField] private ScoreData scoreDataSO;
    public static Action onGameOver;
    public static Action onVictory;

    public override void GameOver()
    {
        //Логика сохранения данных о рекордах 
        /*
         Имя Счёт - 2 столбца
         */
        ScoreRecordData scoreRecordData = new ScoreRecordData();
        scoreRecordData.Name = "PlayerName"; //InputField с именем введеным в начале
        scoreRecordData.Score = scoreDataSO.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        onGameOver?.Invoke();
        SceneManager.LoadScene("GameOverTimeModeScene");
    }

    public override void Victory()
    {
        //Логика сохранения данных о рекордах 
        /*
         Имя Счёт - 2 столбца
         */
        ScoreRecordData scoreRecordData = new ScoreRecordData();
        scoreRecordData.Name = "PlayerName";
        scoreRecordData.Score = scoreDataSO.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        onVictory?.Invoke();
        SceneManager.LoadScene("VictoryTimemodeScene");

    }

    private void MakeRecords()
    {

    }
}
