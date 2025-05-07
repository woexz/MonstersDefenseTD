using UnityEngine;
using UnityEngine.UI;

public class TimeScoreText : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void Start()
    {
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
        _scoreText.text = $"Время: {score}";
    }
}
