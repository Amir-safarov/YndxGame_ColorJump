using TMPro;
using UnityEngine;

public class CoinsValue : MonoBehaviour
{
    private int _coins;
    private int _receivedCoins;
    private int _totalCoins;
    private const string CurrentCoins = "CurrentCoins";

    private void Awake()
    {
        _coins = PlayerPrefs.GetInt(CurrentCoins);
        if (!PlayerPrefs.HasKey(CurrentCoins))
            PlayerPrefs.SetInt(CurrentCoins, _coins);
    }

    public void ActivateCoinsPutOn()
    {
        GlobalEventManager.CoinReceivedEvent.AddListener(AddCoins);
    }

    private void OnEnable()
    {
        ShowCoinsCount();
    }

    private void OnDisable()
    {
        _receivedCoins = 0;
    }

    private void ShowCoinsCount()
    {
        _coins += _receivedCoins;
        GetComponent<TextMeshProUGUI>().text = (_coins).ToString();
        PlayerPrefs.SetInt(CurrentCoins, _coins + _receivedCoins);
    }

    private void AddCoins()
    {
        _receivedCoins++;
    }

    public int GetReceivedCoins()
    {
        return _receivedCoins;
    }
}
