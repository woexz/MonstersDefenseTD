using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _castleSpriteRenderer;

    [SerializeField] private Sprite _castleFullHealthSprite, _castleDamagedSprite1, _castleDamagedSprite2, _castleDamagedSprite3, _castleDestroyedSprite;

    [SerializeField] private int _fullHealthState, _firstDamagedState, _secondDamagedState, _thirdDamagedState, _destroyedState;

    private void Start()
    {
        CastleHeatlh.onHpChange += OnHpChange;
    }

    private void OnDestroy()
    {
        CastleHeatlh.onHpChange -= OnHpChange;
    }

    private void OnHpChange(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth * 100;
        ChangeCastleVisualByHealthProcent(healthPercentage);
    }

    private void ChangeCastleVisualByHealthProcent(float healthPercentage)
    {
        var sprite = GetSpriteByHealthState(healthPercentage);
        if (sprite != _castleSpriteRenderer.sprite)
        {
            _castleSpriteRenderer.sprite = sprite;
        }
    }

    private Sprite GetSpriteByHealthState(float procent)
    {
        if (procent > _firstDamagedState)
        {
            return _castleFullHealthSprite;
        }
        else if (procent <= _firstDamagedState && procent >= _secondDamagedState)
        {
            return _castleDamagedSprite1;
        }
        else if (procent <= _secondDamagedState && procent >= _thirdDamagedState)
        {
            return _castleDamagedSprite2;
        }
        else if (procent <= _thirdDamagedState && procent > _destroyedState)
        {
            return _castleDamagedSprite3;
        }
        else if (procent <= _destroyedState)
        {
            return _castleDestroyedSprite;
        }
        Debug.LogError($"This procent -- {procent} is incorrect");
        return null;
    }
}
