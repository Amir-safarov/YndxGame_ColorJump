using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _powerY;
    [SerializeField] private float _powerX;
    [SerializeField] private float fallForce;

    private Rigidbody2D _rb;

    internal bool _isToRight = true;
    private bool _canMove = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.2f;
        GlobalEventManager.PlayereDeadEvent.AddListener(BlockMove);
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            Move();
        else
        {
            if (!_rb.IsSleeping())
                _rb.AddForce(Vector3.down * fallForce);
        }
    }
    public void OpenMove()
    {
        _canMove = true;
        Move();
    }

    private void BlockMove()
    {
        _rb.Sleep();
    }

    private void Move()
    {
        if (_canMove)
        {
            _rb.IsAwake();
            _rb.gravityScale = 1;
            _rb.velocity = Vector2.zero;
            if (_isToRight)
                _rb.AddForce(new Vector2(_powerX, _powerY), ForceMode2D.Impulse);
            else
                _rb.AddForce(new Vector2(-_powerX, _powerY), ForceMode2D.Impulse);
            if (_rb.velocity.magnitude < 1f)
                Debug.Log("Сила импульса израсходована.");
        }
        else
            BlockMove();
    }
}
