using TMPro;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _scoreCoin;
    private void OnEnable()
    {
        _playerWallet.CoinChanged += OnScoreCoinChanged;
    }

    private void OnDisable()
    {
        _playerWallet.CoinChanged -= OnScoreCoinChanged;
    }

    private void OnScoreCoinChanged(int score)
    {
        _scoreCoin.text = score.ToString();
    }
}
