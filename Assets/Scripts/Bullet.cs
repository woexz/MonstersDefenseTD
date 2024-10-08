using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;        // �������� ����
    [SerializeField] private float _lifetime = 2f;      // ����� ����� ����
    private int _damage = 0;

    // �������, ������� ����� ������� ��� ��������� �������
    public static Action<int> onHit;

    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        // ������� ���� ����� �� ��� X
        _rb.velocity = -transform.up * _speed;
        // ���������� ���� ����� �������� �����
        Destroy(gameObject, _lifetime);
    }

    // ���������� ��� ������������ � ������� ���������
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ����������� �� � ������
        if (collision.gameObject.CompareTag("Castle"))
        {
            // �������� ������� ��������� � ������� ����
            onHit?.Invoke(_damage);
            // ���������� ������ ����� ������������
            Destroy(gameObject);
        }

        
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
