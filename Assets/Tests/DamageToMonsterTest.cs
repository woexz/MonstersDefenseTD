using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DamageToMonsterTest
{
    private Monster monster;

    [SetUp]
    public void SetUp()
    {
        monster = new GameObject().AddComponent<Monster>(); // Создаём объект монстра
        monster.currentHealth = 50; // Начальное здоровье
    }

    [Test]
    public void Monster_TakesDamage()
    {
        monster.TakeDamage(20); // Метод, уменьшающий здоровье
        Assert.AreEqual(30, monster.currentHealth, "Монстр получил урон неправильно!");
    }
}
