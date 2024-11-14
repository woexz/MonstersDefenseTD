using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneController : MonoBehaviour
{
    public void BackToMainMenuOnClick()
    {
        Debug.Log("рррр");
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToNextLevelOnClick()
    {
        //логика перехода на следующий уровень
    }
}
