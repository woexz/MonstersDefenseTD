using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    [SerializeField] private float _frameRate = 60f;
    [SerializeField] private Transform _target;
    private float _secondQuentity = 1.0f;
    [SerializeField] private float _yOffset = 10;
    [SerializeField] private Text _hpAmount;
    [SerializeField] private Image _hpFillBar;

    private float fixetTime = 0;

    private Monster _owner;

    public void SetOwner(Monster owner)
    {
        _owner = owner;
        _target = owner.transform;
    }

    private void OnMonsterDies()
    {
        DestroyHealthBar();
    }

    private void OnMonsterHpChange(int currentHealth)
    {
        ChangeHpAmount(currentHealth);
    }

    private void OnMonsterHpChangeProcent(float hpProcent)
    {
        ChangeHpFillAmount(hpProcent);
    }

    private void Start()
    {
        MonsterHealth.onMonsterDies += OnMonsterDies;
        MonsterHealth.onMonsterHpChange += OnMonsterHpChange;
        MonsterHealth.onMonsterHpChangeProcent += OnMonsterHpChangeProcent;
    }

    private void OnDestroy()
    {
        MonsterHealth.onMonsterDies -= OnMonsterDies;
        MonsterHealth.onMonsterHpChange -= OnMonsterHpChange;
        MonsterHealth.onMonsterHpChangeProcent -= OnMonsterHpChangeProcent;
    }

    private void Update()
    {
        Vector3 position = new Vector3();
        fixetTime += Time.deltaTime;
        if (fixetTime >= _secondQuentity / _frameRate && _target != null)
        {
            position = Camera.main.WorldToScreenPoint(_target.position);
            position.y += _yOffset;
            transform.position = position;

            fixetTime = 0.0f;
        }
    }

    private void ChangeHpAmount(int currentHealth)
    {
        _hpAmount.text = currentHealth.ToString();
    }

    private void ChangeHpFillAmount(float hpProcent)
    {
        _hpFillBar.fillAmount = hpProcent;
    }

    public void SetHpVisual(int maxHealth, int currentHealth)
    {
        //Установка хп монстру
        _hpFillBar.fillAmount = Utils.GetProcent(currentHealth, maxHealth);
        _hpAmount.text = currentHealth.ToString();
    }

    private void DestroyHealthBar()
    {
        Destroy(gameObject);
    }

    


}
