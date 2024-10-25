using UnityEngine;
using UnityEngine.UI;

public class TimeScoreText : MonoBehaviour
{
    private Text _scoreText;
    private void Start()
    {
        _scoreText = GetComponent<Text>();
        ScoreManager.onScoreChange += OnScoreChange;
    }

    private void OnDestroy()
    {
        ScoreManager.onScoreChange -= OnScoreChange;
    }
    private void OnScoreChange(float score)
    {
        ChangeScoreVisual(score);
    }

    private void ChangeScoreVisual(float score)
    {
        _scoreText.text = $"Очки: {score}";
    }
}
