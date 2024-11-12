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

    public static Action<float> onScoreChange;

    [SerializeField] private ScoreData scoreDataSO;

    
    private void Start()
    {
        GameManager.onGameOver += OnGameOver;
        GameManager.onVictory += OnVictory;
    }

    private void OnDestroy()
    {
        GameManager.onGameOver -= OnGameOver;
        GameManager.onVictory -= OnVictory;
    }
    // Метод Awake вызывается при инициализации объекта
    private void Awake()
    {
        timeBetweenFrames = secondQuentity / frameRate;
    }

    private void Update()
    {
        fixetTime += Time.deltaTime;
        if (fixetTime >= secondQuentity / frameRate)
        {
            if (timeBetweenFrames > Time.deltaTime)
            {
                scoreDataSO.score += timeBetweenFrames;
            }
            else
            {
                scoreDataSO.score += Time.deltaTime;
            }
            onScoreChange?.Invoke(scoreDataSO.score);
            fixetTime = 0.0f;
        }
    }

    private void OnGameOver()
    {
        ResetScore();
    }

    private void OnVictory()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        scoreDataSO.score = 0;
        onScoreChange?.Invoke(scoreDataSO.score);
    }
}
