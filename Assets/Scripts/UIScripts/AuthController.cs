using UnityEngine;
using YG;

public class AuthController : MonoBehaviour
{
    [SerializeField] private YandexGame _yg;
    [SerializeField] private GameObject _firstAuthBtn;
    [SerializeField] private GameObject _secondAuthBtn;

    public void AuthOn()
    {
        if (!YandexGame.SDKEnabled)
            return;
        if (YandexGame.auth == false)
            _yg._OpenAuthDialog();
        CheckAuthState();
    }

    private void CheckAuthState()
    {
        print($"Atuh state {YandexGame.auth}");
        _firstAuthBtn.SetActive(!YandexGame.auth);
        _secondAuthBtn.SetActive(!YandexGame.auth);
    }

}
