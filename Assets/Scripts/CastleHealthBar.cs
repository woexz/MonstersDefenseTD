using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Text _hpAmount;
    private void OnHpChangeProcent(float hpProcent)
    {
        //������� �� ������� ����� �������� � �����
        ChangeHpVisual(hpProcent);
    }

    private void OnHpChange(int currentHealth)
    {
        ChangeHpAmount(currentHealth);
    }

    private void Start()
    {
        CastleHeatlh.onHpChangeProcent += OnHpChangeProcent;
        CastleHeatlh.onHpChange += OnHpChange;
    }

    private void OnDestroy()
    {
        CastleHeatlh.onHpChangeProcent -= OnHpChangeProcent;
        CastleHeatlh.onHpChange -= OnHpChange;
    }

    private void ChangeHpVisual(float hpProcent)
    {
        //������ �� �� �����
        _healthBarFill.fillAmount = hpProcent;
    }

    private void ChangeHpAmount(int currentHealth)
    {
        _hpAmount.text = currentHealth.ToString();
    }

    public void SetHpVisual(int maxHealth, int currentHealth)
    {
        //��������� �� �����
        _healthBarFill.fillAmount = Utils.GetProcent(currentHealth, maxHealth);
        _hpAmount.text = currentHealth.ToString();
    }
}
