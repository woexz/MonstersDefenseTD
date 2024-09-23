using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform _hpBar;

    [SerializeField] private MonsterHealth _health;
    [SerializeField] private UIReferences _uiRef;
    public void CreateHpVisual()
    {
        //âèçóàëèçèðîâàòü ïîëîñêó âï è ñîçäàâàòü åå
        var bar = Instantiate(_hpBar, _uiRef.MonstersUIContainer).GetComponent<MonsterHealthBar>();
        _health.SetHealthBar(bar);
        bar.SetOwner(this);
    }
}
