using System;
using System.Diagnostics.Tracing;
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
    private static int gameLaunchCounter;
    private static int _launchCountToBonus = 5;

    private const string LaunchCount = "LaunchCount";
    private const string StarsBonus = "StarsBonus";
    private const string PlayerAuthorized = "PlayerAuthorized";
    private const string GameRated = "GameRated";
    private const string BoughtSkinCount = "BoughtSkinCount";
    private const string DoubleStarsPaid = "BoughtSkinCount";

    private void Awake()
    {
        ResetToDeafoult();
        YandexGame.GetDataEvent += LoadSavedCloud;
        if (!PlayerPrefs.HasKey(GameRated))
            PlayerPrefs.SetInt(GameRated, 0);
        if (!PlayerPrefs.HasKey(PlayerAuthorized))
            PlayerPrefs.SetInt(PlayerAuthorized, 0);
        if (!PlayerPrefs.HasKey(DoubleStarsPaid))
            PlayerPrefs.SetInt(DoubleStarsPaid, 0);

        if (!PlayerPrefs.HasKey(LaunchCount))
            PlayerPrefs.SetInt(LaunchCount, 0);
        if (!PlayerPrefs.HasKey(StarsBonus))
        {
            PlayerPrefs.SetInt(StarsBonus, 1);
            starsBonus = PlayerPrefs.GetInt(StarsBonus);
        }
        _skinsCount = shopItems.skinItems.Count;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSavedCloud;
    }

    public static void ResetGameCounter()
    {
        gameLaunchCounter = PlayerPrefs.GetInt(LaunchCount);
        if (gameLaunchCounter >= _launchCountToBonus)
        {
            showBonuce = true;
            PlayerPrefs.SetInt(LaunchCount, 0);
            gameLaunchCounter = PlayerPrefs.GetInt(LaunchCount);
        }
        else
            showBonuce = false;
    }

    public static void AddGameLauncherCount()
    {
        gameLaunchCounter++;
        PlayerPrefs.SetInt(LaunchCount, gameLaunchCounter);
    }

    public void ResetToDeafoult()
    {
        wallRank = 3;
    }

    private void LoadSavedCloud()
    {
        if (!PlayerPrefs.HasKey(BoughtSkinCount))
            PlayerPrefs.SetInt(BoughtSkinCount, YandexGame.savesData.skinsCount);
        else
            PlayerPrefs.SetInt(BoughtSkinCount, 0);
        BoughtSkinsCount = PlayerPrefs.GetInt(BoughtSkinCount);
        doubleStarsPaid = YandexGame.savesData.doubleStartsBought;
        PlayerPrefs.SetInt(DoubleStarsPaid, 1);
        print("DATA LOADED UNITY, количество скинов, оценка игры и куплен ли бонус");
    }
}
