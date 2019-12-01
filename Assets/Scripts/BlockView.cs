using System;
using UnityEngine;

public class BlockView : MonoBehaviour, IBlockView
{

    #region IBlockView 

    public event EventHandler Hit;

    #endregion

    [SerializeField]
    private SpriteRenderer _viewSpriteRenderer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Hit?.Invoke(this, EventArgs.Empty);
        }
    }
}
