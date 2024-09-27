using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����������� ���������� ��� �������� ������������� ����������
    private static GameManager _instance;

    public static Action onGameOver;

    
    // ��������� ����������� �������� ��� ������� � ����������
    public static GameManager Instance
    {
        get
        {
            // ���� ��������� �� ����������, ������� ���
            if (_instance == null)
            {
                // ������� ����� ������ � ��������� � ���� ��������� GameManager
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }


    public void GameOver()
    {
        //������ ���������� ������ � �������� 
        /*
         ��� ���� - 2 �������
         */
        ScoreRecordData scoreRecordData = new ScoreRecordData();
        scoreRecordData.Name = "PlayerName"; //InputField � ������ �������� � ������
        scoreRecordData.Score = ScoreManager.Instance.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        Time.timeScale = 0f;
        Application.Quit();

    }

    public void Victory()
    {
        //������ ���������� ������ � �������� 
        /*
         ��� ���� - 2 �������
         */
        ScoreRecordData scoreRecordData = new ScoreRecordData();
        scoreRecordData.Name = "PlayerName";
        scoreRecordData.Score = ScoreManager.Instance.score;

        ScoreDataJsonManager.Instance.AddNewRecords(scoreRecordData);
        ScoreDataJsonManager.Instance.SaveScoreRecords();
        Time.timeScale = 0f;
        Application.Quit();

    }

    // ����� Awake ���������� ��� ������������� �������
    private void Awake()
    {
        // ���������, ���������� �� ��� ���������
        if (_instance == null)
        {
            // ���� ��������� �� ����������, ��������� ������� ������ � �� ���������� ��� ��� �������� ����� �����
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���� ��������� ��� ����������, ���������� ������� ������, ����� ��������� ��������������
            Destroy(gameObject);
        }
    }

    
}
