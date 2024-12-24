using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public int mana;
    public int currentCastleHealth;
    public int maxCastleHealth;
    public IGameManager chosenGameManager;
}
