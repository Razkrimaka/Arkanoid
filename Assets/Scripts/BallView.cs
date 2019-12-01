using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public event EventHandler Lose;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.LogError($"Столкновение с {collision.gameObject.tag}");
        if (collision.gameObject.tag == "Finish")
        {
            Lose?.Invoke(this, EventArgs.Empty);
        }
    }
}
