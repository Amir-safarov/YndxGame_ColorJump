using UnityEngine;
using UnityEngine.Events;

public class SetColorForPlayer : MonoBehaviour
{
    [SerializeField] private bool _toRightDirection;
    [SerializeField] private UnityEvent<bool> _touchThePlayer;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().color != _spriteRenderer.color)
        {
            GlobalEventManager.RegistradeOfDead();
            return;
        }
        else
        {
            collision.gameObject.GetComponent<PlayerMove>()._isToRight = _toRightDirection;
            collision.gameObject.GetComponent<PlayerChangeColor>()._isToRight = _toRightDirection;
            _touchThePlayer.Invoke(_toRightDirection);
            GlobalEventManager.SendBounced();
            if (_toRightDirection)
                GlobalEventManager.LeftWallChangeColor();
            else
                GlobalEventManager.RightWallChangeColor();
        }
    }
}
