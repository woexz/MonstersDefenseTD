using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    public int maxHealth = 100;   // ������������ ���������� �������� �����
    private int currentHealth;    // ������� �������� �����
    [SerializeField] private CastleHealthBar _castleHealthBar;

    public static Action<float> onHpChangeProcent;
    public static Action<int> onHpChange;

    private void Start()
    {
        // ������������� �������� �� ������������ � ������ ����
        currentHealth = maxHealth;
        _castleHealthBar.SetHpVisual(maxHealth, currentHealth);
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
        float hpProcent = Utils.GetProcent((float)currentHealth, (float)maxHealth);
        onHpChangeProcent?.Invoke(hpProcent);
        onHpChange?.Invoke(currentHealth);
    }

    

    // ����� ��� ����������� �����
    void Die()
    {
        Debug.Log("����� ��������!");
        // ����� �� ������ �������� �������� ����������, ������� � �.�.
        Destroy(gameObject);
    }

    
}
