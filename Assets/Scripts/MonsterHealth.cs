using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private int maxHealth = 100;  // Максимальное здоровье монстра
    private int currentHealth;   // Текущее здоровье монстра

    public static Action onMonsterDies;

    void Start()
    {
        // Устанавливаем текущее здоровье равным максимальному при старте игры
        currentHealth = maxHealth;
    }

    // Метод для нанесения урона
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Монстр получил урон! Текущее здоровье: " + currentHealth);

        // Если здоровье опускается до 0 или ниже, уничтожаем монстра
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод для уничтожения монстра
    void Die()
    {
        Debug.Log("Монстр уничтожен!");
        // Уничтожаем объект монстра

        //Invoke события
        onMonsterDies?.Invoke();
        Destroy(gameObject);
    }

    // Метод, который вызывается при клике по монстру
    void OnMouseDown()
    {
        // Например, нанесём 10 единиц урона при каждом клике
        TakeDamage(10);
    }
}
