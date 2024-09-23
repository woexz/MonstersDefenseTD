using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    private static ManaManager _instance;
    public static ManaManager Instance
    {
        get
        {
            // Если экземпляр не существует, создаем его
            if (_instance == null)
            {
                // Создаем новый объект и добавляем к нему компонент GameManager
                _instance = new GameObject("GameManager").AddComponent<ManaManager>();
            }
            return _instance;
        }
    }

    public float startMana = 1000f;
    public float currentMana;


    private float frameRate = 60f;
    private float fixetTime = 0;
    private float secondQuentity = 1.0f;


    [SerializeField] private Text ManaAmountText;

    private void Awake()
    {
        ManaAmountText.text = startMana.ToString();
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
    void Start()
    {
        currentMana = startMana;
    }
    private void Update()
    {
        fixetTime += Time.deltaTime;
        if (fixetTime >= secondQuentity / frameRate)
        {
            ManaAmountText.text = currentMana.ToString();
            fixetTime = 0.0f;
        }
    }

    // Метод для траты маны
    public bool UseMana(float amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true; // Достаточно маны
        }
        return false; // Недостаточно маны
    }

    // Метод для восстановления маны
    public void RegenerateMana(int manaForDeath)
    {
        currentMana += manaForDeath;
    }
}
//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    // Статическая переменная для хранения единственного экземпляра
//    private static GameManager _instance;

//    // Публичное статическое свойство для доступа к экземпляру
//    public static GameManager Instance
//    {
//        get
//        {
//            // Если экземпляр не существует, создаем его
//            if (_instance == null)
//            {
//                // Создаем новый объект и добавляем к нему компонент GameManager
//                _instance = new GameObject("GameManager").AddComponent<GameManager>();
//            }
//            return _instance;
//        }
//    }

//    // Метод Awake вызывается при инициализации объекта
//    private void Awake()
//    {
//        // Проверяем, существует ли уже экземпляр
//        if (_instance == null)
//        {
//            // Если экземпляр не существует, назначаем текущий объект и не уничтожаем его при загрузке новой сцены
//            _instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            // Если экземпляр уже существует, уничтожаем текущий объект, чтобы сохранить единственность
//            Destroy(gameObject);
//        }
//    }

//    // Пример метода для управления состоянием игры
//    public void StartGame()
//    {
//        // Логика старта игры
//        Debug.Log("Game Started");
//    }
//}