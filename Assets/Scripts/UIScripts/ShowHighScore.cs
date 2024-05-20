using TMPro;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private BouncedCount _count;
    [SerializeField] private bool _isShowingHighScore;
    [SerializeField] private bool _isShowingCurentScore;

    private void Awake()
    {
        _count.LoadSavesCloud();
    }

    private void OnEnable()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if (_isShowingHighScore && !_isShowingCurentScore)
            text.text = _count.GetHighScore().ToString();
        else
            text.text = _count.GetCurrentScore().ToString();
    }
}
