using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 1000;   // Максимальное количество здоровья замка
    private int _currentHealth = 1000;    // Текущее здоровье замка
    [SerializeField] private CastleHealthBar _castleHealthBar;

    private float _timer = 0f; // Переменная для отслеживания времени

    [SerializeField] PlayerDataSO playerDataSO;

    public static Action<float> onHpChangeProcent;
    public static Action<int, int> onHpChange;

    private void Start()
    {
        SetHp(_currentHealth);
        // Подписываемся на событие снаряда при создании снаряда
        Bullet.onHit += TakeDamage;
    }

    private void OnDestroy()
    {
        Bullet.onHit -= TakeDamage;
    }

    // Метод для нанесения урона замку
    public void TakeDamage(int damage)
    {
        
        SetHp(_currentHealth - damage);
        Debug.Log("Замок получил урон! Текущее здоровье: " + _currentHealth);

        // Если здоровье упало до 0 или ниже, уничтожаем замок
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetHp(int hp)
    {
        _currentHealth = hp; //Выставляем текущее хп с нанесенным уроном
        float hpProcent = Utils.GetProcent((float)_currentHealth, (float)_maxHealth);
        onHpChangeProcent?.Invoke(hpProcent);
        onHpChange?.Invoke(_currentHealth, _maxHealth);
    }

    

    // Метод для уничтожения замка
    private void Die()
    {
        Debug.Log("Замок разрушен!");
        // Здесь вы можете добавить анимацию разрушения, эффекты и т.д.
        TimeModeManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
