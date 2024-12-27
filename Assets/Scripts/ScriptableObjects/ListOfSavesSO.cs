using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ListOfSaves")]
public class ListOfSavesSO : ScriptableObject
{
    public List<PlayerDataToSave> listOfSaves; 
}