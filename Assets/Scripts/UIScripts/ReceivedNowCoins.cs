using TMPro;
using UnityEngine;

public class ReceivedNowCoins : MonoBehaviour
{
    [SerializeField] private CoinsValue _coins;

    private int _receivedCoins;
    private TextMeshProUGUI _receivedCoinText;

    private void Awake()
    {
        _receivedCoinText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _receivedCoins = _coins.GetReceivedCoins();
        if (_receivedCoins == 0)
            _receivedCoinText.text = $"";
        else
            _receivedCoinText.text = $"+{_coins.GetReceivedCoins()}";
    }
}
