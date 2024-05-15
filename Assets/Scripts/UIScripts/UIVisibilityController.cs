using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class UIVisibilityController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Authorization();

    [SerializeField] private bool _isCheckingOnAuth;
    [SerializeField] private GameObject _object;
    [SerializeField] private YandexGame _yg;

    private const string PlayerAuthorized = "PlayerAuthorized";

    private void Awake()
    {
        if (PlayerPrefs.GetInt(PlayerAuthorized) == 1)
            YandexFuntions.playerAuthorized = true;
    }

    public void ObjectOn()
    {

        if (!_isCheckingOnAuth)
            _object.SetActive(true);
        else
        {
            if (YandexGame.auth && YandexGame.SDKEnabled)
                _object.SetActive(true);
            else
                _yg._OpenAuthDialog();
        }
    }

    public void ObjectOff() =>
        _object.SetActive(false);
}
