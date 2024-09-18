using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    [SerializeField] private Transform _monsterPref;

    public void SpawnMonsters(List<MonsterData> data)
    {
        //спавн всех монстров
        foreach (MonsterData monster in data)
        {
            SpawnMonster(monster);
        }
    }

    public void SpawnMonster(MonsterData data)
    {
        //спавн одного монстра
        var monster = Instantiate(_monsterPref).GetComponent<Monster>();
        monster.CreateHpVisual();
    }

    //тестовая часть
    private void Start()
    {
        SpawnMonster(new MonsterData());
    }
}

public class MonsterData
{

}
