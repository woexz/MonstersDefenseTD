using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Статическая переменная для хранения единственного экземпляра
    private static GameManager _instance;

    public static Action onGameOver;

    
    // Публичное статическое свойство для доступа к экземпляру
    public static GameManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
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
        scoreRecordData.Score = ScoreManager.Instance.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        Time.timeScale = 0f;
        Application.Quit();

    }

    public void Victory()
    {
        //Логика сохранения данных о рекордах 
        /*
         Имя Счёт - 2 столбца
         */
        ScoreRecordData scoreRecordData = new ScoreRecordData();
        scoreRecordData.Name = "PlayerName";
        scoreRecordData.Score = ScoreManager.Instance.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        Time.timeScale = 0f;
        Application.Quit();

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
