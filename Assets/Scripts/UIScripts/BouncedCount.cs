using UnityEngine;
using TMPro;
using YG;
using System;
using Unity.VisualScripting;

public class BouncedCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bouncedText;
    private const string HighScore = "HighScore";
    private int _bounced;
    private int _highScore;

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSavesCloud;
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSavesCloud;
    }

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            LoadSavesCloud();

        _highScore = PlayerPrefs.GetInt(HighScore);
        GlobalEventManager.OnPlayerBouncedEvent.AddListener(PlayerBounced);
        GlobalEventManager.ShowBouncedCount.AddListener(UpdateBouced);
    }

    public void LoadSavesCloud()
    {
        if (!PlayerPrefs.HasKey(HighScore))
            PlayerPrefs.SetInt(HighScore, 0);
        else if (YandexGame.savesData.highScore != 0)
            _highScore = YandexGame.savesData.highScore;
        else
            _highScore = PlayerPrefs.GetInt(HighScore);
        PlayerPrefs.SetInt(HighScore, _highScore);
        print($"BOUNCED COUNT LOADED high score  Yandex {YandexGame.savesData.highScore} -- PP {PlayerPrefs.GetInt(HighScore)}");
        YandexGame.SaveProgress();
        GlobalEventManager.InvokeShowHighscore();
    }

    public int GetHighScore()
    {
        if (_highScore != 0)
        {
            print("GOOD NICE");
            return _highScore;
        }
        else
        {
            print("NULL HIGH SCORE DAMN");
            return _highScore;
        }
    }

    public int GetCurrentScore()
    {
        return _bounced;
    }

    private void UpdateBouced()
    {
        _bounced = 0;
        UpdateText();
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
        _bouncedText.text = _bounced.ToString();
    }

    private void CheckHighScore()
    {
        if (_bounced > _highScore && _bounced > YandexGame.savesData.highScore)
        {
            _highScore = _bounced;
            PlayerPrefs.SetInt(HighScore, _highScore);
            if (YandexGame.SDKEnabled && YandexGame.auth)
            { 
                YandexGame.savesData.highScore = _highScore;
                YandexGame.NewLeaderboardScores("ScoreLeaderboard", _highScore);
                print($"Saved new high score\n Yandex {YandexGame.savesData.highScore} - PP {_highScore}");
                YandexGame.SaveProgress();
            }
        }
    }

}


