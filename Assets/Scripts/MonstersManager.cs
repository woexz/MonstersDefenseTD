using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    [SerializeField] private float _spawnRangeX = 8f;      // Диапазон X для случайного спавна
    [SerializeField] private float _spawnRangeY = 1f;      // Диапазон Y для случайного спавна
    [SerializeField] private float minDistanceBetweenMonsters = 2f; // Минимальная дистанция между монстрами
    [SerializeField] private Transform _monsterPref;
    [SerializeField] private int _monstersAmount;

    private List<Vector2> spawnedPositions = new List<Vector2>(); // Хранение позиций монстров

    //public void SpawnMonsters(List<MonsterData> data)
    //{
    //    foreach (MonsterData monster in data)
    //    {
    //        SpawnMonster(monster);
    //    }
    //}

    public void SpawnMonsters(MonsterData data)
    {
        spawnedPositions.Clear();
        
        for (int i = 0; i < _monstersAmount; i++)
        {
            bool validPosition = false;
            Vector2 chosenSpawnPosition;
            // Случайная позиция для спавна монстра
            do
            {
                Vector2 spawnPosition = new Vector2(
                Random.Range(-_spawnRangeX, _spawnRangeX),
                Random.Range(-_spawnRangeY, _spawnRangeY));

                validPosition = IsValidPosition(spawnPosition);
                chosenSpawnPosition = spawnPosition;
            }
            while (!validPosition);
            
            var monster = Instantiate(_monsterPref, chosenSpawnPosition, Quaternion.identity).GetComponent<Monster>();
            monster.CreateHpVisual();
            spawnedPositions.Add(chosenSpawnPosition);
        }
    }

    bool IsValidPosition(Vector2 newPosition)
    {
        foreach (Vector2 pos in spawnedPositions)
        {
            if (Vector2.Distance(newPosition, pos) < minDistanceBetweenMonsters)
            {
                return false; // Позиция слишком близка к уже существующим монстрам
            }
        }

        return true; // Позиция подходит
    }

    private void Start()
    {
        SpawnMonsters(new MonsterData());
    }
}

public class MonsterData
{

}