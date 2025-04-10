using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellMonster : Monster
{
    void Start()
    {
        // Устанавливаем текущее здоровье равным максимальному при старте игры
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }

    
}
