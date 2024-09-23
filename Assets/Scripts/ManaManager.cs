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
            // ���� ��������� �� ����������, ������� ���
            if (_instance == null)
            {
                // ������� ����� ������ � ��������� � ���� ��������� GameManager
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

    // ����� ��� ����� ����
    public bool UseMana(float amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true; // ���������� ����
        }
        return false; // ������������ ����
    }

    // ����� ��� �������������� ����
    public void RegenerateMana(int manaForDeath)
    {
        currentMana += manaForDeath;
    }
}
//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    // ����������� ���������� ��� �������� ������������� ����������
//    private static GameManager _instance;

//    // ��������� ����������� �������� ��� ������� � ����������
//    public static GameManager Instance
//    {
//        get
//        {
//            // ���� ��������� �� ����������, ������� ���
//            if (_instance == null)
//            {
//                // ������� ����� ������ � ��������� � ���� ��������� GameManager
//                _instance = new GameObject("GameManager").AddComponent<GameManager>();
//            }
//            return _instance;
//        }
//    }

//    // ����� Awake ���������� ��� ������������� �������
//    private void Awake()
//    {
//        // ���������, ���������� �� ��� ���������
//        if (_instance == null)
//        {
//            // ���� ��������� �� ����������, ��������� ������� ������ � �� ���������� ��� ��� �������� ����� �����
//            _instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            // ���� ��������� ��� ����������, ���������� ������� ������, ����� ��������� ��������������
//            Destroy(gameObject);
//        }
//    }

//    // ������ ������ ��� ���������� ���������� ����
//    public void StartGame()
//    {
//        // ������ ������ ����
//        Debug.Log("Game Started");
//    }
//}