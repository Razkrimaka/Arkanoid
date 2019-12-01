using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    public void Move (Vector2 force)
    {
        _rigidbody2D.AddForce(force, ForceMode2D.Force);
    }
}
