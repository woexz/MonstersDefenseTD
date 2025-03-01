using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public float mana;
    public int currentCastleHealth;
    public int maxCastleHealth;

    [SerializeField] private AbstactLevelManager _chosenGameManager;
    public AbstactLevelManager ChosenGameManager
    {
        get 
        {
            Debug.LogError(0);
            return _chosenGameManager; 
        }
        set 
        {
            Debug.LogError(1);
            _chosenGameManager = value;
        }
    }
    public string currentLevel;
}
