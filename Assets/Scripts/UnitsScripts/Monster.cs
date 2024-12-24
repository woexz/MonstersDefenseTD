using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy
{
    [SerializeField] private Transform _hpBar;
    protected MonsterHealthBar _monsterHealthBar;
    protected int currentHealth;

    private IGameManager _gameManager;

    public static Action<int> onMonsterDies;

    public void SetHealthBar(MonsterHealthBar bar)
    {
        _monsterHealthBar = bar;
    }

    public void CreateHpVisual(Transform container)
    {
        var bar = Instantiate(_hpBar, container).GetComponent<MonsterHealthBar>();
        SetHealthBar(bar);
        bar.SetOwner(this);
    }

    void Start()
    {
        // Устанавливаем текущее здоровье равным максимальному при старте игры
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);

        //_gameManager = 
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
    }

    // Метод для уничтожения монстра
    void Die()
    {
        onMonsterDies?.Invoke(manaForKill);
        Debug.Log("Монстр уничтожен!");

        _monsterHealthBar.DestroyHealthBar();
        var monsters = FindObjectsOfType<Monster>();
        if (monsters == null || monsters.Length <= 1)
        {
            TimeModeManager.Instance.Victory();
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
