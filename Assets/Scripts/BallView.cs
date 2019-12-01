using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public event EventHandler<string> Collision;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Collision?.Invoke(this, collision.gameObject.tag);
    }
}
