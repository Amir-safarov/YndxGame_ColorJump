using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _powerY;
    [SerializeField] private float _powerX;

    private Rigidbody2D _rb;

    internal bool _isToRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
}
