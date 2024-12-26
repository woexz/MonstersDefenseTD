using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public float mana;
    public int currentCastleHealth;
    public int maxCastleHealth;
    public IGameManager chosenGameManager;
    public string currentLevel;
}
