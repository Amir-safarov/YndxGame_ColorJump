using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int wallRank;
    public static int gameLaunchCounter =9;
    public static bool showBonuce;

    private void Awake()
    {
        ResetToDeafoult();
    }

    public static void ResetGameCounter()
    {
        if (gameLaunchCounter == 10)
        {
            showBonuce = true;
            gameLaunchCounter = 0;
        }
    }

    public void ResetToDeafoult()
    {
        wallRank = 3;
    }
}
