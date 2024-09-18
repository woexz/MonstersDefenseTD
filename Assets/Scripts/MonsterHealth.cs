using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private int maxHealth = 100;  // Максимальное здоровье монстра
    private int currentHealth;   // Текущее здоровье монстра

    [SerializeField] private MonsterHealthBar _monsterHealthBar;

    public static Action onMonsterDies;
    public static Action<int> onMonsterHpChange;
    public static Action<float> onMonsterHpChangeProcent;

    void Start()
    {
        // Устанавливаем текущее здоровье равным максимальному при старте игры
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }

    // Метод для нанесения урона
    private void TakeDamage(int damage)
    {
        SetHp(currentHealth - damage);
        Debug.Log("Монстр получил урон! Текущее здоровье: " + currentHealth);

        // Если здоровье опускается до 0 или ниже, уничтожаем монстра
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp; //Выставляем текущее хп с нанесенным уроном
        float hpProcent = Utils.GetProcent((float)currentHealth, (float)maxHealth);
        onMonsterHpChangeProcent?.Invoke(hpProcent);
        onMonsterHpChange?.Invoke(currentHealth); //Вызываем событие изменения хп монстра
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
