using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOReferencesController : MonoBehaviour
{
    [SerializeField] private UIReferences _uiRef;

    [SerializeField] private Transform _monsterUIContainer;

    private void Awake()
    {
        _uiRef.MonstersUIContainer = _monsterUIContainer;
    }
}