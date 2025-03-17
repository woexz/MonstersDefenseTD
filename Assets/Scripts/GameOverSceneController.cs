using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerDataSO;

    public void TryAgainOnClick()
    {
        Debug.LogError(playerDataSO.ChosenGameManager);
        SceneManager.LoadScene("TimeMode");
        Debug.LogError(playerDataSO.ChosenGameManager);
    }

    public void BackToMainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
