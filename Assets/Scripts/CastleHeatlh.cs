using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    public int maxHealth = 100;   // Максимальное количество здоровья замка
    private int currentHealth;    // Текущее здоровье замка

    private void Start()
    {
        // Устанавливаем здоровье на максимальное в начале игры
        currentHealth = maxHealth;
        // Подписываемся на событие снаряда при создании снаряда

        Bullet.OnHit += TakeDamage;

    }

    private void OnDestroy()
    {
        Bullet.OnHit -= TakeDamage;
    }

    // Метод для нанесения урона замку
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Замок получил урон! Текущее здоровье: " + currentHealth);

        // Если здоровье упало до 0 или ниже, уничтожаем замок
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод для уничтожения замка
    void Die()
    {
        Debug.Log("Замок разрушен!");
        // Здесь вы можете добавить анимацию разрушения, эффекты и т.д.
        Destroy(gameObject);
    }
}
