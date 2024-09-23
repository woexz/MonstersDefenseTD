using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;  // ������������ �������� �������
    [SerializeField] private int currentHealth;   // ������� �������� �������
    [SerializeField] public int _manaForDeath; //������� ���� ��������� �� ������ �������


    private MonsterHealthBar _monsterHealthBar;

    public static Action<int> onMonsterHpChange;
    public static Action<float> onMonsterHpChangeProcent;

    void Start()
    {
        // ������������� ������� �������� ������ ������������� ��� ������ ����
        currentHealth = maxHealth;
        _monsterHealthBar.SetHpVisual(maxHealth, currentHealth);
    }

    public void SetHealthBar(MonsterHealthBar bar)
    {
        _monsterHealthBar = bar;
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
        //onMonsterHpChangeProcent?.Invoke(hpProcent);
        _monsterHealthBar.ChangeHpFillAmount(hpProcent);
        _monsterHealthBar.ChangeHpAmount(currentHealth);
        //onMonsterHpChange?.Invoke(currentHealth); //�������� ������� ��������� �� �������
    }

    // ����� ��� ����������� �������
    void Die()
    {
        Debug.Log("������ ���������!");

        //Invoke �������
        //_manaManager.RegenerateMana(_manaForDeath);
        ManaManager.Instance.RegenerateMana(_manaForDeath);
        _monsterHealthBar.DestroyHealthBar();
        var monsters = FindObjectsOfType<Monster>();
        if (monsters == null || monsters.Length <= 1) 
        {
            GameManager.Instance.Victory();
        }
        Destroy(gameObject);
    }

    // �����, ������� ���������� ��� ����� �� �������
    void OnMouseDown()
    {
        // ��������, ������ 10 ������ ����� ��� ������ �����
        TakeDamage(10);
    }
}
