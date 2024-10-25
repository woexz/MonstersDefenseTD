using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float frameRate = 60f;
    private float fixetTime = 0;
    private float secondQuentity = 1.0f;

    private float timeBetweenFrames;

    public float score {  get; private set; } 

    public static Action<float> onScoreChange;

    // Статическая переменная для хранения единственного экземпляра
    private static ScoreManager _instance;

    // Публичное статическое свойство для доступа к экземпляру
    public static ScoreManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
            }
            return _instance;
        }
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
        timeBetweenFrames = secondQuentity / frameRate;
    }

    private void Update()
    {
        fixetTime += Time.deltaTime;
        if (fixetTime >= secondQuentity / frameRate)
        {
            if (timeBetweenFrames > Time.deltaTime)
            {
                score += timeBetweenFrames;
            }
            else
            {
                score += Time.deltaTime;
            }
            onScoreChange?.Invoke(score);
            fixetTime = 0.0f;
        }
    }
}
