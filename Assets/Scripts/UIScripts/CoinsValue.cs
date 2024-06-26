using TMPro;
using UnityEngine;
using YG;
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
        YandexGame.RewardVideoEvent += GetAdReward;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= GetAdReward;
    }

    public void ShowRewardAd() =>
        YandexGame.RewVideoShow(1);

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

    public void GetAdReward(int usellesIndex)
    {
        _receivedCoins += 100;
        UpdateCurrentCoinsValue();
    }

    internal void UpdateCurrentCoinsValue()
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
        if (YandexGame.savesData.money != 0)
            Coins = YandexGame.savesData.money;
        else
            Coins = PlayerPrefs.GetInt(CurrentCoins);
    }

    private void SetCurrentCoins()
    {
        PlayerPrefs.SetInt(CurrentCoins, Coins + _receivedCoins);
        PlayerPrefs.Save();
        Coins = PlayerPrefs.GetInt(CurrentCoins);
        if (YandexGame.SDKEnabled)
        {
            YandexGame.savesData.money = Coins;
            YandexGame.SaveProgress();
            print($"Saved new MONEY count Yandex {YandexGame.savesData.money} - PP {Coins}");
        }
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
        if (GlobalVariables.doubleStarsPaid || YandexGame.savesData.doubleStartsBought)
            _receivedCoins += 2;
        else
            _receivedCoins += 1;
    }
}