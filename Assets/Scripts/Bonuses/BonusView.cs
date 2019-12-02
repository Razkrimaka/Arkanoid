using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusView : MonoBehaviour, IBonusView
{
    #region IBonusView

    public event EventHandler<string> Collision;

    public void SetBonus(Bonuses bonusId)
    {
        _spriteRenderer.sprite = Resources.Load<Sprite>($"Sprites/{bonusId}");
    }

    public void Throw(Vector3 position, Vector3 force)
    {
        this.transform.position = position;
        this.gameObject.SetActive(true);
        _rigidbody.WakeUp();
        _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void Stop()
    {
        _rigidbody.Sleep();
    }

    public GameObject GameObject => gameObject;

    #endregion

    #region MonoBehaviour

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            return;
        }

        Collision?.Invoke(this, collision.gameObject.tag);
    }

    #endregion

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Rigidbody2D _rigidbody;
}
