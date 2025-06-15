using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonsterBubbled : PreplacedMonster
{
    [SerializeField] GameObject _bubble;
    [SerializeField] float _minTimeBeetweenState;
    [SerializeField] float _maxTimeBeetweenState;

    private bool _isBubbleActive;

    private void Awake()
    {
        StartCoroutine(RandomShieldActivationCouratine());
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void OnMouseDown()
    {
        if (!_isBubbleActive)
        {
            TakeDamage(damage);
        }
    }

    private void ShowBubble()
    {
        _bubble.SetActive(true);
        _isBubbleActive = true;
    }

    private void HideBubble()
    {
        _bubble.SetActive(false);
        _isBubbleActive = false;
    }

    IEnumerator RandomShieldActivationCouratine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(_minTimeBeetweenState, _maxTimeBeetweenState));
            if (_isBubbleActive)
                HideBubble();
            else
                ShowBubble();
        }
    }
}
