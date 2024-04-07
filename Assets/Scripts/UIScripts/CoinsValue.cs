using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsValue : MonoBehaviour
{
    private int _coins;
    private int _receivedCoins;
    private const string CurrentCoins = "CurrentCoins";

    public int Coins
    {
        get
        {
            if (_coins <= 0)
                return 0;
            else return _coins;
        }
        set { _coins = value; }
    }

    private void Awake()
    {
        UpdateCurrentCoinsValue();
        GlobalEventManager.CoinView.AddListener(UpdateCurrentCoinsValue);
        GlobalEventManager.ResetReceivedCoins.AddListener(ResetReceivedCoins);
    }

    private void OnEnable()
    {
        UpdateCurrentCoinsValue();
    }

    public int GetReceivedCoins()
    {
        return _receivedCoins;
    }

    public void BuyNewSkin()
    {
        Coins -= 100;
        SetCurrentCoins();
    }

    public int GetCurrentCoinsCount()
    {
        SetCurrentCoins();
        GetSavedCoins();
        return Coins;
    }

    public void ActivateCoinsPutOn()
    {
        GlobalEventManager.CoinReceivedEvent.AddListener(AddCoins);
    }

    public void GetBonus()
    {
        _receivedCoins += 20;
        UpdateCurrentCoinsValue();
    }

    public void ResetBonuceShow()
    {
        GlobalVariables.showBonuce = false;
    }

    private void UpdateCurrentCoinsValue()
    {
        GetSavedCoins();
        SetCurrentCoins();
        GetSavedCoins();
        ShowCoinsCount();
        _receivedCoins = 0;
    }

    private void GetSavedCoins()
    {
        if (!PlayerPrefs.HasKey(CurrentCoins))
            PlayerPrefs.SetInt(CurrentCoins, Coins);
        Coins = PlayerPrefs.GetInt(CurrentCoins);
    }

    private void SetCurrentCoins()
    {
        PlayerPrefs.SetInt(CurrentCoins, Coins + _receivedCoins);
        PlayerPrefs.Save();
    }


    private void ShowCoinsCount()
    {
        GetComponent<TextMeshProUGUI>().text = (Coins).ToString();
    }

    private void ResetReceivedCoins()
    {
        _receivedCoins = 0;
    }

    private void AddCoins()
    {
        _receivedCoins++;
    }
}