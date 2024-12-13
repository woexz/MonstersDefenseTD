using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreplacedMonster : Monster
{
    [SerializeField] private StorylineReferencesSO _storylneReferencesSO;

    void Start()
    {
        CreateHpVisual(_storylneReferencesSO.monstersUIContainer);
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }
}
