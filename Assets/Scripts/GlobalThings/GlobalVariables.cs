using System.Diagnostics.Tracing;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int wallRank;
    public static int starsBonus;
    public static bool showBonuce;

    private static int gameLaunchCounter;
    private static int _launchCountToBonus = 1;

    private const string LaunchCount = "LaunchCount";
    private const string StarsBonus = "StarsBonus";

    private void Awake()
    {
        ResetToDeafoult();
        if (!PlayerPrefs.HasKey(LaunchCount))
            PlayerPrefs.SetInt(LaunchCount, 0);
        if (!PlayerPrefs.HasKey(StarsBonus))
        {
            PlayerPrefs.SetInt(StarsBonus, 1);
            starsBonus = PlayerPrefs.GetInt(StarsBonus);
        }

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

    public void GetDoubleStartsBonus()
    {
        //TODO
    }
}
