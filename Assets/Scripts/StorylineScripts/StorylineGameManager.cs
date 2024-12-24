using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorylineGameManager : MonoBehaviour, IGameManager
{
    // Статическая переменная для хранения единственного экземпляра
    private static StorylineGameManager _instance;

    // Публичное статическое свойство для доступа к экземпляру
    public static StorylineGameManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("StorylineGameManager").AddComponent<StorylineGameManager>();
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
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Victory()
    {
        SceneManager.LoadScene("VictoryStorylineScene");
    }
}
