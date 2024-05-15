using UnityEngine;
using YG;

public class GlobalVariables : MonoBehaviour
{
    [SerializeField] private ShopItems shopItems;
    public static int wallRank;
    public static int starsBonus;
    public static bool showBonuce;
    public static bool doubleStarsPaid;

    public static int BoughtSkinsCount
    {
        get
        {
            if (_boughtSkinsCount < 0)
                _boughtSkinsCount = 0;
            if (_boughtSkinsCount > _skinsCount)
                _boughtSkinsCount = _skinsCount;
            return _boughtSkinsCount;
        }
        set => _boughtSkinsCount = value;
    }

    private static int _boughtSkinsCount;
    private static int _skinsCount;
    private static int _gameLaunchCounter;
    private static int _launchCountToBonus = 5;

    private const string HighScore = "HighScore";
    private const string LaunchCount = "LaunchCount";
    private const string BoughtSkinCount = "BoughtSkinCount";
    private const string CurrentCoins = "CurrentCoins";

    private void Awake()
    {
        ResetToDeafoult();
        YandexGame.GetDataEvent += LoadSavedCloud;

        if (!PlayerPrefs.HasKey(LaunchCount))
            PlayerPrefs.SetInt(LaunchCount, 0);
        _skinsCount = shopItems.skinItems.Count;
    }

    private void OnDisable() =>
        YandexGame.GetDataEvent -= LoadSavedCloud;

    public static void ResetGameCounter()
    {
        _gameLaunchCounter = PlayerPrefs.GetInt(LaunchCount);
        if (_gameLaunchCounter >= _launchCountToBonus)
        {
            showBonuce = true;
            PlayerPrefs.SetInt(LaunchCount, 0);
            _gameLaunchCounter = PlayerPrefs.GetInt(LaunchCount);
        }
        else
            showBonuce = false;
    }

    public static void AddGameLauncherCount()
    {
        _gameLaunchCounter++;
        PlayerPrefs.SetInt(LaunchCount, _gameLaunchCounter);
    }

    public void ResetToDeafoult() =>
        wallRank = 3;

    private void LoadSavedCloud()
    {
        if (!YandexGame.SDKEnabled)
            return;
        if (!PlayerPrefs.HasKey(BoughtSkinCount))
            PlayerPrefs.SetInt(BoughtSkinCount, YandexGame.savesData.skinsCount);
        else
            BoughtSkinsCount = PlayerPrefs.GetInt(BoughtSkinCount);
        doubleStarsPaid = YandexGame.savesData.doubleStartsBought;
        if (YandexGame.savesData.skinsCount == 1)
            PlayerPrefs.SetInt(CurrentCoins, YandexGame.savesData.money);
        else
            PlayerPrefs.SetInt(CurrentCoins, ((YandexGame.savesData.skinsCount * 100) + YandexGame.savesData.money));

        print($"DATA LOADED UNITY, {BoughtSkinsCount} и {doubleStarsPaid}," +
            $" а так же лучший счет {PlayerPrefs.GetInt(HighScore)}. Так же монеты: {PlayerPrefs.GetInt(CurrentCoins)}");
    }
}
