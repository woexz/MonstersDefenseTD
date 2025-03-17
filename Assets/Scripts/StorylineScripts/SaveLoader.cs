using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoader : MonoBehaviour
{
    [SerializeField] private Transform content; // Ссылка на Content в Scroll View
    [SerializeField] private GameObject saveButtonPrefab; // Префаб кнопки
    private string saveFilePath;

    private void Start()
    {
        // Путь к JSON-файлу
        saveFilePath = Path.Combine(Application.persistentDataPath, @"saveProgressData.json");

        // Загружаем сохранения при запуске
        LoadSaves();
    }

    private void LoadSaves()
    {
        // Проверяем, существует ли файл
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Файл сохранений не найден.");
            return;
        }

        // Загружаем JSON файл
        string json = File.ReadAllText(saveFilePath);

        // Десериализуем список сохранений
        List<PlayerDataToSave> saves = JsonConvert.DeserializeObject<List<PlayerDataToSave>>(json);

        // Создаем кнопки для каждого сохранения
        foreach (PlayerDataToSave save in saves)
        {
            CreateSaveButton(save);
        }
    }

    private void CreateSaveButton(PlayerDataToSave save)
    {
        // Создаем кнопку на основе префаба
        GameObject button = Instantiate(saveButtonPrefab, content);

        // Настраиваем текст кнопки
        Text buttonText = button.GetComponentInChildren<Text>();
        buttonText.text = $"Level: {save.currentLevel} | Mana: {save.mana}";

        // Добавляем обработчик нажатия
        button.GetComponent<Button>().onClick.AddListener(() => LoadGame(save));

    }

    private void LoadGame(PlayerDataToSave save)
    {
        Debug.Log($"Загрузка сохранения: {save.currentLevel}");
        // Реализуйте логику загрузки сохранения, например:
        // 1. Загрузите уровень из save.currentLevel.
        // 2. Восстановите состояние замка и маны из сохранения.
    }
}
