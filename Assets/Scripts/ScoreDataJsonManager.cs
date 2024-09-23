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
    // Статическая переменная для хранения единственного экземпляра
    private static ScoreDataJsonManager _instance;

    // Публичное статическое свойство для доступа к экземпляру
    public static ScoreDataJsonManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("ScoreDataJsonManager").AddComponent<ScoreDataJsonManager>();
            }
            return _instance;
        }
    }
    public void SaveScoreRecords()
    {
        //заполнение so с типами квестов
        JsonSerializer serializer = new JsonSerializer();
        //serializer.Serialize(writer, _scoreRecordDatas);
        string json = JsonConvert.SerializeObject(_scoreRecordDatas);
        File.WriteAllText(SAVE_FILE_PATH, json);

    }

    public void AddNewRecords(ScoreRecordData data)
    {
        _scoreRecordDatas.Add(data);
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
    private void Start()
    {
        LoadScoreRecords();
    }
    private void LoadScoreRecords()
    {
        
        //заполнение so с типами квестов
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