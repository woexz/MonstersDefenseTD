using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    public int maxHealth = 100;   // Максимальное количество здоровья замка
    private int currentHealth;    // Текущее здоровье замка

    public static Action<float> onHpChangeProcent;

    private void Start()
    {
        // Устанавливаем здоровье на максимальное в начале игры
        currentHealth = maxHealth;
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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp;
        float hpProcent = GetHpProcent();
        onHpChangeProcent?.Invoke(hpProcent);
    }

    private float GetHpProcent()
    {
        return (float)currentHealth / (float)maxHealth;
    }

    // Метод для уничтожения замка
    void Die()
    {
        Debug.Log("Замок разрушен!");
        // Здесь вы можете добавить анимацию разрушения, эффекты и т.д.
        Destroy(gameObject);
    }
}
