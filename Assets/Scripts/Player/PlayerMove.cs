using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        Time.timeScale = 1.3f;
        GlobalEventManager.PlayereDeadEvent.AddListener(BlockMove);
        Move();
    }

    private void Update()
    {
        PLayerRotate();
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            Move();
    }

    private void PLayerRotate()
    {
        if (_isToRight)
            transform.Rotate(0, 0, -100 * Time.deltaTime);
        else
            transform.Rotate(0, 0, 100 * Time.deltaTime);

    }

    public void OpenMove()
    {
        _canMove = true;
        Move();
    }

    private void BlockMove()
    {
        _rb.gravityScale = 0;
        _rb.Sleep();
        transform.position = new Vector2(-2, 0);
        _canMove = false;
        _isToRight = true;
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
        }
        else
            BlockMove();
    }
}
