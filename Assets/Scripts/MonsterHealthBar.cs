using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterHealthBar : MonoBehaviour
{
    [SerializeField] private float _frameRate = 60f;

    [SerializeField] private Transform _target;
    private float _secondQuentity = 1.0f;
    [SerializeField] private float _yOffset = 10;

    private float fixetTime = 0;

    private void Start()
    {
        MonsterHealth.onMonsterDies += OnMonsterDies;
    }

    private void OnDestroy()
    {
        MonsterHealth.onMonsterDies -= OnMonsterDies;
    }

    private void Update()
    {
        Vector3 position = new Vector3();
        fixetTime += Time.deltaTime;
        if (fixetTime >= _secondQuentity / _frameRate && _target != null)
        {
            position = Camera.main.WorldToScreenPoint(_target.position);
            position.y += _yOffset;
            transform.position = position;

            fixetTime = 0.0f;
        }
    }

    private void OnMonsterDies()
    {
        DestroyHealthBar();
    }

    private void DestroyHealthBar()
    {
        Destroy(gameObject);
    }
}
