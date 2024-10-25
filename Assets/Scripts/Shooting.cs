using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Префаб пули
    public Transform FirePoint;          // Точка, откуда стреляем
    public float fireRate = 0.5f;     // Задержка между выстрелами
    private float nextFireTime = 0f;  // Время, когда можно будет снова стрелять
    [SerializeField] private int _damage;

    void Update()
    {
        // Если прошло достаточно времени с последнего выстрела
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Создаём пулю в позиции сопла с ориентацией сопла
        var bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
        bullet.SetDamage(_damage);
    }
}
