using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class CheckRateGame : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();


    [SerializeField] private GameObject _rateGameButton;
    [SerializeField] private YandexGame _yg;

    private void OnEnable()
    {
        _rateGameButton.SetActive(YandexGame.EnvironmentData.reviewCanShow);
        YandexGame.ReviewSentEvent += ActiveReview;
    }

    private void OnDisable()
    {
        YandexGame.ReviewSentEvent -= ActiveReview;
    }

    private void ActiveReview(bool active)
    {
        if (!active)
            return;
        if (!YandexGame.SDKEnabled)
            return;
        _rateGameButton.SetActive(YandexGame.EnvironmentData.reviewCanShow);
    }

    public void InvokeRateGame()
    {
        if (YandexGame.auth && YandexGame.SDKEnabled)
            YandexGame.ReviewShow(true);
        else
            _yg._OpenAuthDialog();
    }
}
