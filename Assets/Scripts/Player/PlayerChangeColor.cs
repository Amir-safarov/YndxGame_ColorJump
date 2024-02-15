using System.Collections;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    [SerializeField] private DeterminationColorsForWalls _rightWall;
    [SerializeField] private DeterminationColorsForWalls _leftWall;

    private SpriteRenderer _sp;
    internal bool _isToRight = true;

    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitToChange());
    }

    public void GetNewColor()
    {
        int _colorIndex;
        if (_isToRight)
        {
            _colorIndex = Random.Range(0, 3);
            _sp.color = _rightWall.sideColor[_colorIndex];
        }
        else
        {
            _colorIndex = Random.Range(0, 3);
            _sp.color = _leftWall.sideColor[_colorIndex];
        }
    }

    private IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(0.01f);
        GetNewColor();
    }
}
