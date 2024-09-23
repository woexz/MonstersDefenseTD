using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;   // Максимальное количество здоровья замка
    private int currentHealth;    // Текущее здоровье замка
    [SerializeField] private CastleHealthBar _castleHealthBar;

    public static Action<float> onHpChangeProcent;
    public static Action<int> onHpChange;
    private bool _isDead = false;

    private void Start()
    {
        // Устанавливаем здоровье на максимальное в начале игры
        currentHealth = _maxHealth;
        _castleHealthBar.SetHpVisual(_maxHealth, currentHealth);
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
        
        SetHp(currentHealth - damage);
        Debug.Log("Замок получил урон! Текущее здоровье: " + currentHealth);

        // Если здоровье упало до 0 или ниже, уничтожаем замок
        if (currentHealth <= 0 && !_isDead)
        {

            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp; //Выставляем текущее хп с нанесенным уроном
        float hpProcent = Utils.GetProcent((float)currentHealth, (float)_maxHealth);
        onHpChangeProcent?.Invoke(hpProcent);
        onHpChange?.Invoke(currentHealth);
    }

    

    // Метод для уничтожения замка
    void Die()
    {
        _isDead = true;
        Debug.Log("Замок разрушен!");
        // Здесь вы можете добавить анимацию разрушения, эффекты и т.д.
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    
}
