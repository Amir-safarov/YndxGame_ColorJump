using UnityEngine;
using YG;

public class CheckAuthState : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(!YandexGame.auth);
    }
    private void Awake()
    {
        gameObject.SetActive(!YandexGame.auth);
    }
    private void OnEnable()
    {
        gameObject.SetActive(!YandexGame.auth);
    }

    private void OnDisable()
    {
        gameObject.SetActive(!YandexGame.auth);
    }
}
