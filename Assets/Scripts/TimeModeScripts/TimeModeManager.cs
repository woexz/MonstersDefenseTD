using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeModeManager : MonoBehaviour, IGameManager
{
    // Статическая переменная для хранения единственного экземпляра
    private static TimeModeManager _instance;

    [SerializeField] private ScoreData scoreDataSO;
    public static Action onGameOver;
    public static Action onVictory;


    // Публичное статическое свойство для доступа к экземпляру
    public static TimeModeManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("TimeModeManager").AddComponent<TimeModeManager>();
            }
            return _instance;
        }
    }


    public void GameOver()
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
        SceneManager.LoadScene("GameOverScene");
    }

    public void Victory()
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

    // Метод Awake вызывается при инициализации объекта
    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр
        if (_instance == null)
        {
            // Если экземпляр не существует, назначаем текущий объект и не уничтожаем его при загрузке новой сцены
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Если экземпляр уже существует, уничтожаем текущий объект, чтобы сохранить единственность
            Destroy(gameObject);
        }
    }


}
