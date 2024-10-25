using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreDataJsonManager : MonoBehaviour
{
    private string _saveFilePath;
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
                Debug.LogError("this component is not found, try in ather scene");
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
        File.WriteAllText(_saveFilePath, json);

    }

    public void AddNewRecords(ScoreRecordData data)
    {
        Debug.LogError(_scoreRecordDatas);
        _scoreRecordDatas.Add(data);
    }

    // Метод Awake вызывается при инициализации объекта
    private void Awake()
    {
        _saveFilePath = Path.Combine(Application.persistentDataPath, @"saveData.json");

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
        Debug.LogError(_saveFilePath);
        if (!File.Exists(_saveFilePath))
        {
            
            File.Create(_saveFilePath);
            return;
        }
        //заполнение so с типами квестов
        using (StreamReader sr = new StreamReader(_saveFilePath))
        {

            string json = sr.ReadToEnd();
            _scoreRecordDatas = JsonConvert.DeserializeObject<List<ScoreRecordData>>(json);
            if(_scoreRecordDatas == null)
            {
                _scoreRecordDatas = new List<ScoreRecordData>();
            }

        }
    }

    

    
}

public class ScoreRecordData
{
    public string Name;
    public float Score;
}