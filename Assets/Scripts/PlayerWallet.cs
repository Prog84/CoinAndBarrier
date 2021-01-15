using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public event UnityAction<int> CoinTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            IncreaseCoin();
            collision.gameObject.SetActive(false);
        }
    }

    private void IncreaseCoin()
    {
        _coins++;
        CoinTaken?.Invoke(_coins);
    }
}