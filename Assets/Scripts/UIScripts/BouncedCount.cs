using UnityEngine;
using TMPro;

public class BouncedCount : MonoBehaviour
{
    private const string HighScore = "HighScore";
    private int _bounced;
    private int _highScore;

    private void OnDisable()
    {
        UpdateText();
        _bounced = 0;
    }

    private void OnEnable()
    {
        UpdateText();
        _bounced = 0;
    }

    private void Awake()
    {
        if(!PlayerPrefs.HasKey(HighScore))
            PlayerPrefs.SetInt(HighScore,0);
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt(HighScore);
        GlobalEventManager.OnPlayerBouncedEvent.AddListener(PlayerBounced);
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

    private void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = _bounced.ToString();
    }

    private void CheckHighScore()
    {
        if(_bounced > _highScore)
        {
            _highScore= _bounced;
            PlayerPrefs.SetInt(HighScore,_highScore);
        }
    }

}


