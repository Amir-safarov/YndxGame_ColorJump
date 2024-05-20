using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighlightObject : MonoBehaviour
{
    [SerializeField] private Image _AuthObj;
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;
    private float colorChangeSpeed = 0.5f; 
    private float actionTime = 1.5f; 
    public void StartHighlight()
    {
        StartCoroutine(PulseColor());
    }

    private IEnumerator PulseColor()
    {
        yield return StartCoroutine(ChangeColor(_firstColor, _secondColor));
        yield return StartCoroutine(ChangeColor(_secondColor, _firstColor));
    }

    private IEnumerator ChangeColor(Color startColor, Color endColor)
    {
        float elapsedTime = 0f;
        while (elapsedTime < actionTime)
        {
            _AuthObj.color = Color.Lerp(startColor, endColor, elapsedTime);
            elapsedTime += Time.deltaTime * colorChangeSpeed;
            yield return null;
        }
        _AuthObj.color = endColor;
    }
}
