using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;
    private void OnHpChangeProcent(float hpProcent)
    {
        //������� �� ������� ����� �������� � �����
        ChangeHpVisual(hpProcent);
    }

    private void Start()
    {
        CastleHeatlh.onHpChangeProcent += OnHpChangeProcent;
    }

    private void OnDestroy()
    {
        CastleHeatlh.onHpChangeProcent -= OnHpChangeProcent;
    }

    private void ChangeHpVisual(float hpProcent)
    {
        //������ �� �� �����
        _healthBarFill.fillAmount = hpProcent;
    }
}
