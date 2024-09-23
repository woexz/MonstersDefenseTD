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

    // ����������� ���������� ��� �������� ������������� ����������
    private static ScoreManager _instance;

    // ��������� ����������� �������� ��� ������� � ����������
    public static ScoreManager Instance
    {
        get
        {
            // ���� ��������� �� ����������, ������� ���
            if (_instance == null)
            {
                // ������� ����� ������ � ��������� � ���� ��������� GameManager
                _instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
            }
            return _instance;
        }
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
