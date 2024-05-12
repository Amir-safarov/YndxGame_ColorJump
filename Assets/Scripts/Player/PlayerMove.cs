using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private TrailRenderer _playersTrail;
    [SerializeField] private float _powerY;
    [SerializeField] private float _powerX;

    private const float _timeScale = 1.4f;
    private const int _rotationSpeed = 130;

    private Rigidbody2D _rb;

    internal bool _isToRight = true;
    private bool _canMove = false;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        Time.timeScale = _timeScale;
        Move();
    }

    private void Update()
    {
        PLayerRotate();
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            Move();
    }

    public void OpenMove()
    {
        _canMove = true;
        _playersTrail.emitting = true;
        Move();
    }

    public void BlockMove()
    {
        _rb.gravityScale = 0;
        _rb.Sleep();
        _canMove = false;
        _isToRight = true;
    }

    private void PLayerRotate()
    {
        if (_isToRight)
            transform.Rotate(0, 0, -_rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
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
