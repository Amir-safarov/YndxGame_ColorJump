using UnityEngine;
using UnityEngine.Events;

public class PlayerRedirection : MonoBehaviour
{
    [SerializeField] private bool _toRightDirection;
    [SerializeField] private UnityEvent<bool> _touchThePlayer;
    [SerializeField] private AudioSource _bounceEffect;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
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
            PlaySound();
            collision.gameObject.GetComponent<PlayerMove>()._isToRight = _toRightDirection;
            collision.gameObject.GetComponent<PlayerChangeColor>()._isToRight = _toRightDirection;
            _touchThePlayer.Invoke(_toRightDirection);
            GlobalEventManager.SendBounced();
            GlobalEventManager.SendToCoinRespawn();
            if (_toRightDirection)
                GlobalEventManager.LeftWallChangeColor();
            else
                GlobalEventManager.RightWallChangeColor();
        }
    }

    private void PlaySound()
    {
        if (_bounceEffect == null)
            return;
        _bounceEffect.Play();
    }
}
