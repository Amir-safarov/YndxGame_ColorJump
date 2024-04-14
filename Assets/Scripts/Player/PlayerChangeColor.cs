using System.Collections;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    [SerializeField] private DeterminationColorsForWalls _rightWall;
    [SerializeField] private DeterminationColorsForWalls _leftWall;
    [SerializeField] private TrailRenderer _playersTrail;

    private SpriteRenderer _sp;
    internal bool _isToRight = true;

    int _colorIndex;

    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitToChange());
    }


    public void GetNewColor()
    {
        if (_isToRight)
        {
            _colorIndex = Random.Range(0, GlobalVariables.wallRank);
            _sp.color = _rightWall.sideColor[_colorIndex];
            ChangeTrailColor();
        }
        else
        {
            _colorIndex = Random.Range(0, GlobalVariables.wallRank);
            _sp.color = _leftWall.sideColor[_colorIndex];
            ChangeTrailColor();
        }
    }

    public void ResetDirection()
    {
        _isToRight = true;
    }

    private void ChangeTrailColor()
    {
        _playersTrail.startColor = _sp.color;
        _playersTrail.endColor = _sp.color;
    }

    private IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(0.01f);
        GetNewColor();
    }
}
