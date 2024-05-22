using UnityEngine;
using YG;

public class CheckAuthState : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(!YandexGame.auth);
    }

    private void OnDisable()
    {
        gameObject.SetActive(!YandexGame.auth);
    }
}
