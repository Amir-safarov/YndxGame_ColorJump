using TMPro;
using UnityEngine;
using YG;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private BouncedCount _count;
    [SerializeField] private bool _isShowingHighScore;
    [SerializeField] private bool _isShowingCurentScore;


    private void Awake()
    {
        GlobalEventManager.ShowScoreAfterInitEvent.AddListener(ShowScore);
    }
    private void Start()
    {
        ShowScore();
    }
    private void OnEnable()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if (_isShowingHighScore && !_isShowingCurentScore)
            text.text = _count.GetHighScore().ToString();
        else
            text.text = _count.GetCurrentScore().ToString();
    }
}
