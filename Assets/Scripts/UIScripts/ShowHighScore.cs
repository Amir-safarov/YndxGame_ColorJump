using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private BouncedCount _count;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool _isShowingHighScore;
    [SerializeField] private bool _isShowingCurentScore;

    private void Awake()
    {
        _count.LoadSavesCloud();
    }

    private void OnEnable()
    {
        if (_isShowingHighScore && !_isShowingCurentScore)
        {
            _text.text = _count.GetHighScore().ToString();
            print("High score view");
        }
        else
            _text.text = _count.GetCurrentScore().ToString();
    }
}
