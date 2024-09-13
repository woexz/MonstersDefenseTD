using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;        // Скорость пули
    [SerializeField] private float _lifetime = 2f;      // Время жизни пули
    [SerializeField] private int _damage = 10;

    // Событие, которое будет вызвано при попадании снаряда
    public static Action<int> OnHit;

    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        // Двигаем пулю вперёд по оси X
        _rb.velocity = -transform.up * _speed;
        // Уничтожаем пулю через заданное время
        Destroy(gameObject, _lifetime);
    }

    // Вызывается при столкновении с другими объектами
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулись ли с замком
        if (collision.gameObject.CompareTag("Castle"))
        {
            // Вызываем событие попадания и передаём урон
            OnHit?.Invoke(_damage);
        }

        // Уничтожаем снаряд после столкновения
        Destroy(gameObject);
    }
}
