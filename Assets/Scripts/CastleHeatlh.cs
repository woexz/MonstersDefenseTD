using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    public int maxHealth = 100;   // ������������ ���������� �������� �����
    private int currentHealth;    // ������� �������� �����

    private void Start()
    {
        // ������������� �������� �� ������������ � ������ ����
        currentHealth = maxHealth;
        // ������������� �� ������� ������� ��� �������� �������

        Bullet.OnHit += TakeDamage;

    }

    private void OnDestroy()
    {
        Bullet.OnHit -= TakeDamage;
    }

    // ����� ��� ��������� ����� �����
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("����� ������� ����! ������� ��������: " + currentHealth);

        // ���� �������� ����� �� 0 ��� ����, ���������� �����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ��� ����������� �����
    void Die()
    {
        Debug.Log("����� ��������!");
        // ����� �� ������ �������� �������� ����������, ������� � �.�.
        Destroy(gameObject);
    }
}
