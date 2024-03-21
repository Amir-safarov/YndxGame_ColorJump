using TMPro;
using UnityEngine;

public class CoinsValue : MonoBehaviour
{
    private int _coins;
    private int _receivedCoins;
    private const string CurrentCoins = "CurrentCoins";

    private void Awake()
    {
        GetSavedCoins();
        GlobalEventManager.CoinView.AddListener(UpdateCurrentCoinsValue);
    }

    private void OnEnable()
    {
        UpdateCurrentCoinsValue();
    }


    private void OnDisable()
    {
        _receivedCoins = 0;
    }

    public int GetReceivedCoins()
    {
        return _receivedCoins;
    }

    public void BuyNewSkin()
    {
        _coins -= 100;
        SetCurrentCoins();
    }

    public int GetCurrentCoinsCount()
    {
        FoldCoins();
        GetSavedCoins();
        return _coins;
    }

    public void GetBonus()
    {
        _receivedCoins += 20;
        SetCurrentCoins();
        GetSavedCoins();
        ShowCoinsCount();
    }

    public void ResetBonuceShow()
    {
        GlobalVariables.showBonuce = false;
    }

    private void UpdateCurrentCoinsValue()
    {
        SetCurrentCoins();
        GetSavedCoins();
        ShowCoinsCount();
        _receivedCoins = 0;
    }
    private void GetSavedCoins()
    {
        _coins = PlayerPrefs.GetInt(CurrentCoins);
        if (!PlayerPrefs.HasKey(CurrentCoins))
            PlayerPrefs.SetInt(CurrentCoins, _coins);
    }

    private void SetCurrentCoins()
    {
        PlayerPrefs.SetInt(CurrentCoins, _coins + _receivedCoins);
    }

    public void ActivateCoinsPutOn()
    {
        GlobalEventManager.CoinReceivedEvent.AddListener(AddCoins);
    }

    private void ShowCoinsCount()
    {
        GetComponent<TextMeshProUGUI>().text = (_coins).ToString();
    }

    private void FoldCoins()
    {
        _coins += _receivedCoins;
    }

    private void AddCoins()
    {
        _receivedCoins++;
    }
}
