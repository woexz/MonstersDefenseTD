using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScoreData")]
public class ScoreData : ScriptableObject
{
    public string name;
    public float score;
}
