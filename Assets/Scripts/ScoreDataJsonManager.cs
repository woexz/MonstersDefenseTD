using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json.Linq;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;

public class ScoreDataJsonManager : MonoBehaviour
{
    private const string SAVE_FILE_PATH = @"c:\ScoreRecords.json";
    private List<ScoreRecordData> _scoreRecordDatas = new List<ScoreRecordData>();
    // ����������� ���������� ��� �������� ������������� ����������
    private static ScoreDataJsonManager _instance;

    // ��������� ����������� �������� ��� ������� � ����������
    public static ScoreDataJsonManager Instance
    {
        get
        {
            // ���� ��������� �� ����������, ������� ���
            if (_instance == null)
            {
                // ������� ����� ������ � ��������� � ���� ��������� GameManager
                _instance = new GameObject("ScoreDataJsonManager").AddComponent<ScoreDataJsonManager>();
            }
            return _instance;
        }
    }
    public void SaveScoreRecords()
    {
        //���������� so � ������ �������
        JsonSerializer serializer = new JsonSerializer();
        //serializer.Serialize(writer, _scoreRecordDatas);
        string json = JsonConvert.SerializeObject(_scoreRecordDatas);
        File.WriteAllText(SAVE_FILE_PATH, json);

    }

    public void AddNewRecords(ScoreRecordData data)
    {
        _scoreRecordDatas.Add(data);
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
    private void Start()
    {
        LoadScoreRecords();
    }
    private void LoadScoreRecords()
    {
        
        //���������� so � ������ �������
        using (StreamReader sr = new StreamReader(SAVE_FILE_PATH))
        {

            string json = sr.ReadToEnd();
            _scoreRecordDatas = JsonConvert.DeserializeObject<List<ScoreRecordData>>(json);

        }
    }

    

    
}

public class ScoreRecordData
{
    public string Name;
    public float Score;
}