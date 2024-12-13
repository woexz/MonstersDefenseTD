using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorylineReferencesManager : MonoBehaviour
{
    [SerializeField] private StorylineReferencesSO _storylineReferencesSO;
    [SerializeField] private Transform _monstersHealthBarContainer;

    private void Awake()
    {
        _storylineReferencesSO.monstersUIContainer = _monstersHealthBarContainer;
    }
}
