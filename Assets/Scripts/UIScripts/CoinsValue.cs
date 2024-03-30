using TMPro;
using UnityEngine;

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
        GetSavedCoins();
        GlobalEventManager.CoinView.AddListener(UpdateCurrentCoinsValue);
    }

    private void OnEnable()
    {
        GetSavedCoins();
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

    private void FoldCoins()
    {
        Coins += _receivedCoins;
    }

    private void AddCoins()
    {
        _receivedCoins++;
    }
}
