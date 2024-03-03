using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]

public class AutoAdjustCircleCollider : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _collider;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        AdjustColliderSize();
    }

    private void AdjustColliderSize()
    {
        float spriteSize = Mathf.Max(_spriteRenderer.bounds.size.x, _spriteRenderer.bounds.size.y);
        _collider.radius = spriteSize/2f; 
    }
}
