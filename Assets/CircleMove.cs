using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] private DeterminationColorsForWalls _rightWall;
    [SerializeField] private DeterminationColorsForWalls _leftWall;
    [SerializeField] private float _powerY = 5.2f;
    [SerializeField] private float _powerX = 2.5f;

    private Colors _color;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private int _previousColorIndex;

    internal bool _isToRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitToChange());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            Move();
    }
    private void Move()
    {
        _rb.velocity = Vector2.zero;
        if (_isToRight)
            _rb.AddForce(new Vector2(_powerX, _powerY), ForceMode2D.Impulse);
        else
            _rb.AddForce(new Vector2(-_powerX, _powerY), ForceMode2D.Impulse);
    }

    public void GetNewColor()
    {
        int _colorIndex =-1;
        if (_isToRight)
        {
            _colorIndex = Random.Range(0, _rightWall.sideColor.Count);
            _sp.color = _rightWall.sideColor[_colorIndex];
        }
        else
        {
            _colorIndex = Random.Range(0, _leftWall.sideColor.Count);
            _sp.color = _leftWall.sideColor[_colorIndex];
        }
        Debug.Log($"Color changed on");
    }
    private IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(0.01f);
        GetNewColor();
    }
}
