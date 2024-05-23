using UnityEngine;
using YG;

public class GlobalVariables : MonoBehaviour
{
    [SerializeField] private ShopItems shopItems;
    [SerializeField] private GameObject _doubleStarsObj;

    public static int wallRank;
    public static int starsBonus;
    public static bool showBonuce;
    public static bool doubleStarsPaid;

    public static int BoughtSkinsCount
    {
        get
        {
            if (_boughtSkinsCount < 1)
                _boughtSkinsCount = 1;
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
    private const string BoughtSkinCount = "BoughtSkinCount";

    private void Awake()
    {
        ResetToDeafoult();
        if (!PlayerPrefs.HasKey(LaunchCount))
            PlayerPrefs.SetInt(LaunchCount, 0);
        _skinsCount = shopItems.skinItems.Count;
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSavedCloud;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSavedCloud;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            LoadSavedCloud();
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
            PlayerPrefs.SetInt(BoughtSkinCount, 1);
        BoughtSkinsCount = PlayerPrefs.GetInt(BoughtSkinCount);
        print($"GLOBAL VARIABLES DATA LOADED,\n количество скинов Yandex {YandexGame.savesData.skinsCount} - PP {PlayerPrefs.GetInt(BoughtSkinCount)}");
        print($"GLOBAL VARIABLES DATA LOADED 2{YandexGame.savesData.doubleStartsBought}");
        _doubleStarsObj.SetActive(!YandexGame.savesData.doubleStartsBought);
        YandexGame.SaveProgress();
    }
}
