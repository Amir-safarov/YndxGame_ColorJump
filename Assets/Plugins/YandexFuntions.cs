using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexFuntions : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CheckAuth();

    private const string PlayerAuthorized = "PlayerAuthorized";
    public static bool playerAuthorized;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(PlayerAuthorized) == 1)
            playerAuthorized = true;
    }

    public void InvokeCheckAuth() =>
        CheckAuth();

    public void CheckAuthState(bool _playerAuthed)
    {
        playerAuthorized = _playerAuthed;
        PlayerPrefs.SetInt(PlayerAuthorized, 0);
    }
}
