using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // ������ ����
    public Transform FirePoint;          // �����, ������ ��������
    public float fireRate = 0.5f;     // �������� ����� ����������
    private float nextFireTime = 0f;  // �����, ����� ����� ����� ����� ��������
    [SerializeField] private int _damage;

    void Update()
    {
        // ���� ������ ���������� ������� � ���������� ��������
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // ������ ���� � ������� ����� � ����������� �����
        var bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
        bullet.SetDamage(_damage);
    }
}
