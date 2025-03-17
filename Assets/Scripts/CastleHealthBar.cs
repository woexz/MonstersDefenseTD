using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Text _hpAmount;

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
    private void OnHpChangeProcent(float hpProcent)
    {
        //Реакция на событие смены здоровья в замке
        ChangeHpVisual(hpProcent);
    }

    private void OnHpChange(int currentHealth, int maxHealth)
    {
        ChangeHpAmount(currentHealth);
    }

    private void ChangeHpVisual(float hpProcent)
    {
        //Меняет хп на шкале
        _healthBarFill.fillAmount = hpProcent;
    }

    private void ChangeHpAmount(int currentHealth)
    {
        _hpAmount.text = currentHealth.ToString();
    }
}
