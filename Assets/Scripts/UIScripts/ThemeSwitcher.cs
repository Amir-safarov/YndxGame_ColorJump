using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeSwitcher : MonoBehaviour
{
    private string currentTheme;

    private const string ThemeNow = "ThemeNow";
    private const string LightTheme = "LightTheme";
    private const string DarkTheme = "DarkTheme";
    private const string darkBackgroundSideColor = "DimGrey";
    private const string lightBackgroundSideColor = "beige";

    private Color darkBackgroundThemeStyle = new Color(0.047f, 0.047f, 0.047f);
    private Color lightBackgroundThemeStyle = new Color(0.984f, 0.968f, 0.925f);
    private Color darkTextThemeStyle = new Color(1f, 1f, 1f);
    private Color lightTextThemeStyle = new Color(0.0823f, 0.0823f, 0.0823f);
    private Color lightThemeGreenColor = new Color(0.4f, 1f, 0f);


    [SerializeField] private bool _isLightTheme;
    [SerializeField] private Image _buttonsImage;
    [SerializeField] private Sprite _lightThemeIcon;
    [SerializeField] private Sprite _darkThemeIcon;
    [SerializeField] private Camera _camera;
    [SerializeField] private TextMeshProUGUI _gameName;
    [SerializeField] private TextMeshProUGUI _tapToPlayText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _mainBestScore;
    [SerializeField] private TextMeshProUGUI _skinMainText;
    [SerializeField] private Image _skinBG;
    [SerializeField] private Image _skinCoinIcon;
    [SerializeField] private TextMeshProUGUI _shopsCoinCountText;
    [SerializeField] private TextMeshProUGUI _restartCoinCountText;
    [SerializeField] private Image _restartBG;
    [SerializeField] private TextMeshProUGUI _scoreCount;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _benefidsMainText;
    [SerializeField] private Image _benefidsBG;
    [SerializeField] private Image _leaderboardBG;
    [SerializeField] private Text _leaderboardText;
    [SerializeField] private TextMeshProUGUI _leaderboardTitle;
    [SerializeField] private Image _authUIBG;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(ThemeNow))
            PlayerPrefs.SetString(ThemeNow, DarkTheme);
        currentTheme = PlayerPrefs.GetString(ThemeNow);
        CompareSaveAndBoolTheme();
        SwitchThemeIcon();
        UpdateTheme();
    }

    public void ThemeSwitch()
    {
        _isLightTheme = !_isLightTheme;
        SwitchThemeIcon();
    }

    private void CompareSaveAndBoolTheme()
    {
        if (currentTheme == DarkTheme)
            _isLightTheme = false;
        else
            _isLightTheme = true;
    }

    private void UpdateTheme()
    {
        if (currentTheme == LightTheme)
        {
            _camera.backgroundColor = lightBackgroundThemeStyle;
            _gameName.color = lightTextThemeStyle;
            _tapToPlayText.color = lightTextThemeStyle;
            _scoreText.color = lightTextThemeStyle;
            _mainBestScore.color = lightTextThemeStyle;
            _skinMainText.color = lightTextThemeStyle;
            _shopsCoinCountText.color = lightTextThemeStyle;
            _restartCoinCountText.color = lightTextThemeStyle;
            _scoreCount.color = lightTextThemeStyle;
            _bestScoreText.color = lightTextThemeStyle;
            _bestScore.color = lightTextThemeStyle;
            _benefidsMainText.color = lightTextThemeStyle;
            _benefidsBG.color = lightBackgroundThemeStyle;
            _restartBG.color = lightBackgroundThemeStyle;
            _skinBG.color = lightBackgroundThemeStyle;
            _skinCoinIcon.color = lightThemeGreenColor;
            _leaderboardBG.color = lightBackgroundThemeStyle;
            _authUIBG.color = lightBackgroundThemeStyle;
            _leaderboardText.color = lightTextThemeStyle;
            _leaderboardTitle.color = lightTextThemeStyle;
            GlobalEventManager.ChangeSideColor(lightBackgroundSideColor);
        }
        else
        {
            _camera.backgroundColor = darkBackgroundThemeStyle;
            _gameName.color = darkTextThemeStyle;
            _tapToPlayText.color = darkTextThemeStyle;
            _scoreText.color = darkTextThemeStyle;
            _mainBestScore.color = darkTextThemeStyle;
            _skinMainText.color = darkTextThemeStyle;
            _shopsCoinCountText.color = darkTextThemeStyle;
            _restartCoinCountText.color = darkTextThemeStyle;
            _scoreCount.color = darkTextThemeStyle;
            _bestScoreText.color = darkTextThemeStyle;
            _bestScore.color = darkTextThemeStyle;
            _benefidsMainText.color = darkTextThemeStyle;
            _benefidsBG.color = darkBackgroundThemeStyle;
            _restartBG.color = darkBackgroundThemeStyle;
            _skinBG.color = darkBackgroundThemeStyle;
            _skinCoinIcon.color = darkTextThemeStyle;
            _leaderboardBG.color = darkBackgroundThemeStyle;
            _authUIBG.color = darkBackgroundThemeStyle;
            _leaderboardText.color = darkTextThemeStyle;
            _leaderboardTitle.color = darkTextThemeStyle;
            GlobalEventManager.ChangeSideColor(darkBackgroundSideColor);
        }
    }

    private void SwitchThemeIcon()
    {
        if (_isLightTheme)
        {
            _buttonsImage.sprite = _lightThemeIcon;
            PlayerPrefs.SetString(ThemeNow, LightTheme);
            currentTheme = PlayerPrefs.GetString(ThemeNow);
            UpdateTheme();
        }
        else
        {
            _buttonsImage.sprite = _darkThemeIcon;
            PlayerPrefs.SetString(ThemeNow, DarkTheme);
            currentTheme = PlayerPrefs.GetString(ThemeNow);
            UpdateTheme();
        }
    }
}
