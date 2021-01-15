using TMPro;
using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _scoreCoin;

    private void OnEnable()
    {
        _playerWallet.CoinTaken += OnScoreCoinChanged;
    }

    private void OnDisable()
    {
        _playerWallet.CoinTaken -= OnScoreCoinChanged;
    }

    private void OnScoreCoinChanged(int score)
    {
        _scoreCoin.text = score.ToString();
    }
}
