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
        Debug.LogError($"Сила броска бонуса: {force}");
        _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    #endregion

    #region MonoBehaviour

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            return;
        }

        Collision?.Invoke(this, collision.gameObject.tag);

        _rigidbody.Sleep();
        this.gameObject.SetActive(false);
    }

    #endregion

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Rigidbody2D _rigidbody;
}
