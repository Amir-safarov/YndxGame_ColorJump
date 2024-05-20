using UnityEngine;
using TMPro;
using YG;
using System;
using Unity.VisualScripting;

public class BouncedCount : MonoBehaviour
{
    private const string HighScore = "HighScore";
    private int _bounced;
    private int _highScore;

    private void OnDisable()
    {
        UpdateText();
        YandexGame.GetDataEvent -= LoadSavesCloud;
        _bounced = 0;
    }

    private void OnEnable()
    {
        UpdateText();
        _bounced = 0;
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(HighScore))
            PlayerPrefs.SetInt(HighScore, 0);
        YandexGame.GetDataEvent += LoadSavesCloud;
        if (YandexGame.SDKEnabled)
            LoadSavesCloud();
        GlobalEventManager.OnPlayerBouncedEvent.AddListener(PlayerBounced);
    }

    public void LoadSavesCloud()
    {
        _highScore = YandexGame.savesData.highScore;
        _highScore = PlayerPrefs.GetInt(HighScore);
        print(YandexGame.savesData.highScore + " Loaded High Score");
        PlayerPrefs.SetInt(HighScore, _highScore);
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    public int GetCurrentScore()
    {
        return _bounced;
    }
    private void PlayerBounced()
    {
        _bounced++;
        CheckHighScore();
        UpdateText();
        GlobalEventManager.SendToUpgrade(_bounced);
    }

    public void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = _bounced.ToString();
    }

    private void CheckHighScore()
    {
        if (_bounced > _highScore)
        {
            _highScore = _bounced;
            PlayerPrefs.SetInt(HighScore, _highScore);
            YandexGame.savesData.highScore = _highScore;
            if (!YandexGame.SDKEnabled)
                return;
            YandexGame.NewLeaderboardScores("ScoreLeaderboard", _highScore);
            YandexGame.SaveProgress();
        }
    }

}


