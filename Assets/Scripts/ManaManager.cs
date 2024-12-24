using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    

    public float startMana = 1000f;
    public float currentMana;


    private float frameRate = 60f;
    private float fixetTime = 0;
    private float secondQuentity = 1.0f;


    [SerializeField] private Text ManaAmountText;

    void Start()
    {
        ManaAmountText.text = startMana.ToString();
        currentMana = startMana;
        Monster.onMonsterDies += RegenerateMana;
    }

    private void OnDestroy()
    {
        Monster.onMonsterDies -= RegenerateMana;
    }
    private void Update()
    {
        fixetTime += Time.deltaTime;
        if (fixetTime >= secondQuentity / frameRate)
        {
            ManaAmountText.text = currentMana.ToString();
            fixetTime = 0.0f;
        }
    }

    // Метод для траты маны
    public bool UseMana(float amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true; // Достаточно маны
        }
        return false; // Недостаточно маны
    }

    // Метод для восстановления маны
    void RegenerateMana(int manaForDeath)
    {
        currentMana += manaForDeath;
    }
}