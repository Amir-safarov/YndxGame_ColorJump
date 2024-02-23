using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int wallRank;

    private void Awake()
    {
        ResetToDeafoult();
    }

    public void ResetToDeafoult()
    {
        wallRank = 3;
    }
}
