using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class CheckRateGame : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();


    [SerializeField] private GameObject _rateGameButton;
    [SerializeField] private HighlightObject _highlightObj;

    private void OnEnable()
    {
        YandexGame.ReviewSentEvent += ActiveReview;
    }

    private void OnDisable()
    {
        YandexGame.ReviewSentEvent -= ActiveReview;
    }

    private void ActiveReview(bool active)
    {
        if (active)
            return;
        if (!YandexGame.SDKEnabled)
            return;
        _rateGameButton.SetActive(YandexGame.EnvironmentData.reviewCanShow);
    }

    public void InvokeRateGame()
    {
        print($"Atuh state {YandexGame.auth}");
        if (YandexGame.auth && YandexGame.SDKEnabled)
            YandexGame.ReviewShow(true);
        else
            _highlightObj.StartHighlight();
    }
}
