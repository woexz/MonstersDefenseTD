using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;  // Максимальное здоровье монстра
    [SerializeField] private int currentHealth;   // Текущее здоровье монстра
    [SerializeField] public int _manaForDeath; //Сколько маны начислить за смерть монстра


    private MonsterHealthBar _monsterHealthBar;

    public static Action<int> onMonsterHpChange;
    public static Action<float> onMonsterHpChangeProcent;

    void Start()
    {
        // Устанавливаем текущее здоровье равным максимальному при старте игры
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }

    public void SetHealthBar(MonsterHealthBar bar)
    {
        _monsterHealthBar = bar;
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
        //onMonsterHpChangeProcent?.Invoke(hpProcent);
        _monsterHealthBar.ChangeHpFillAmount(hpProcent);
        _monsterHealthBar.ChangeHpAmount(currentHealth);
        //onMonsterHpChange?.Invoke(currentHealth); //Вызываем событие изменения хп монстра
    }

    // Метод для уничтожения монстра
    void Die()
    {
        Debug.Log("Монстр уничтожен!");

        //Invoke события
        //_manaManager.RegenerateMana(_manaForDeath);
        ManaManager.Instance.RegenerateMana(_manaForDeath);
        _monsterHealthBar.DestroyHealthBar();
        var monsters = FindObjectsOfType<Monster>();
        if (monsters == null || monsters.Length <= 1) 
        {
            GameManager.Instance.Victory();
        }
        Destroy(gameObject);
    }

    // Метод, который вызывается при клике по монстру
    void OnMouseDown()
    {
        // Например, нанесём 10 единиц урона при каждом клике
        TakeDamage(10);
    }
}
