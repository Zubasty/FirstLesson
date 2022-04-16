using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerCoin;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _playerCoin.AddedScore += OnAddedScore;
    }

    private void OnDisable()
    {
        _playerCoin.AddedScore -= OnAddedScore;       
    }

    private void OnAddedScore(int score)
    {
        _text.text = score.ToString();
    }
}
