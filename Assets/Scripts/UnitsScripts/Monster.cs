using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy
{
    [SerializeField] private Transform _hpBar;
    protected MonsterHealthBar _monsterHealthBar;
    protected int currentHealth;

    public static Action<int> onMonsterDies;

    public void SetHealthBar(MonsterHealthBar bar)
    {
        _monsterHealthBar = bar;
    }

    public void CreateHpVisual(Transform container)
    {
        //âèçóàëèçèðîâàòü ïîëîñêó âï è ñîçäàâàòü åå
        var bar = Instantiate(_hpBar, container).GetComponent<MonsterHealthBar>();
        SetHealthBar(bar);
        bar.SetOwner(this);
        
    }
}
