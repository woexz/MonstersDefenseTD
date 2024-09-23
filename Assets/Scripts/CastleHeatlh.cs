using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHeatlh : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;   // ������������ ���������� �������� �����
    private int currentHealth;    // ������� �������� �����
    [SerializeField] private CastleHealthBar _castleHealthBar;

    public static Action<float> onHpChangeProcent;
    public static Action<int> onHpChange;
    private bool _isDead = false;

    private void Start()
    {
        // ������������� �������� �� ������������ � ������ ����
        currentHealth = _maxHealth;
        _castleHealthBar.SetHpVisual(_maxHealth, currentHealth);
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
        if (currentHealth <= 0 && !_isDead)
        {

            Die();
        }
    }

    private void SetHp(int hp)
    {
        currentHealth = hp; //���������� ������� �� � ���������� ������
        float hpProcent = Utils.GetProcent((float)currentHealth, (float)_maxHealth);
        onHpChangeProcent?.Invoke(hpProcent);
        onHpChange?.Invoke(currentHealth);
    }

    

    // ����� ��� ����������� �����
    void Die()
    {
        _isDead = true;
        Debug.Log("����� ��������!");
        // ����� �� ������ �������� �������� ����������, ������� � �.�.
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    
}
