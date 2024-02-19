using TMPro;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] private BouncedCount count;
    [SerializeField] private bool _isShowingHighScore;
    [SerializeField] private bool _isShowingCurentScore;

    private void OnEnable()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if (_isShowingHighScore && !_isShowingCurentScore)
            text.text = count.GetHighScore().ToString();
        else
            text.text = count.GetCurrentScore().ToString();
    }
}
