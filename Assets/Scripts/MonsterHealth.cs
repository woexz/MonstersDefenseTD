using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private int maxHealth = 100;  // ������������ �������� �������
    private int currentHealth;   // ������� �������� �������

    public static Action onMonsterDies;

    void Start()
    {
        // ������������� ������� �������� ������ ������������� ��� ������ ����
        currentHealth = maxHealth;
    }

    // ����� ��� ��������� �����
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("������ ������� ����! ������� ��������: " + currentHealth);

        // ���� �������� ���������� �� 0 ��� ����, ���������� �������
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ��� ����������� �������
    void Die()
    {
        Debug.Log("������ ���������!");
        // ���������� ������ �������

        //Invoke �������
        onMonsterDies?.Invoke();
        Destroy(gameObject);
    }

    // �����, ������� ���������� ��� ����� �� �������
    void OnMouseDown()
    {
        // ��������, ������ 10 ������ ����� ��� ������ �����
        TakeDamage(10);
    }
}
