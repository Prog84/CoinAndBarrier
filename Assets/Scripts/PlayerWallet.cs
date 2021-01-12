using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coin;

    public event UnityAction<int> CoinChanged;

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
        _coin++;
        CoinChanged?.Invoke(_coin);
    }
}