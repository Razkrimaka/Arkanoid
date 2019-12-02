using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private BoxCollider2D _boxCollider;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public void Move (Vector2 force)
    {
        _rigidbody2D.AddForce(force, ForceMode2D.Force);
    }

    public void SetWidth(float width)
    {
        _boxCollider.size = new Vector2(width, ColliderHeight);
        _spriteRenderer.size = new Vector2(width, ColliderHeight);
    }

    private const float  ColliderHeight = 50;
}
