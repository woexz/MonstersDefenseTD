using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    public int maxHealth = 100;   // ������������ ���������� �������� �����
    private int currentHealth;    // ������� �������� �����

    public static Action<float> onHpChangeProcent;

    private void Start()
    {
        // ������������� �������� �� ������������ � ������ ����
        currentHealth = maxHealth;
        // ������������� �� ������� ������� ��� �������� �������

        Bullet.onHit += TakeDamage;

    }

    private void OnDestroy()
    {
        Bullet.onHit -= TakeDamage;
    }

    // ����� ��� ��������� ����� �����
    public void TakeDamage(int damage)
    {
        
        SetHp(currentHealth - damage);
        Debug.Log("����� ������� ����! ������� ��������: " + currentHealth);

        // ���� �������� ����� �� 0 ��� ����, ���������� �����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp;
        float hpProcent = GetHpProcent();
        onHpChangeProcent?.Invoke(hpProcent);
    }

    private float GetHpProcent()
    {
        return (float)currentHealth / (float)maxHealth;
    }

    // ����� ��� ����������� �����
    void Die()
    {
        Debug.Log("����� ��������!");
        // ����� �� ������ �������� �������� ����������, ������� � �.�.
        Destroy(gameObject);
    }
}
