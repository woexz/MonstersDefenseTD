using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private int maxHealth = 100;  // ������������ �������� �������
    private int currentHealth;   // ������� �������� �������

    [SerializeField] private MonsterHealthBar _monsterHealthBar;

    public static Action onMonsterDies;
    public static Action<int> onMonsterHpChange;
    public static Action<float> onMonsterHpChangeProcent;

    void Start()
    {
        // ������������� ������� �������� ������ ������������� ��� ������ ����
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }

    // ����� ��� ��������� �����
    private void TakeDamage(int damage)
    {
        SetHp(currentHealth - damage);
        Debug.Log("������ ������� ����! ������� ��������: " + currentHealth);

        // ���� �������� ���������� �� 0 ��� ����, ���������� �������
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp; //���������� ������� �� � ���������� ������
        float hpProcent = Utils.GetProcent((float)currentHealth, (float)maxHealth);
        onMonsterHpChangeProcent?.Invoke(hpProcent);
        onMonsterHpChange?.Invoke(currentHealth); //�������� ������� ��������� �� �������
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
