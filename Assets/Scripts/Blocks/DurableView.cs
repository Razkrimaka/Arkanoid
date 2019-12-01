using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurableView : MonoBehaviour, IDurableView
{
    #region IDurableView

    void IDurableView.SetDurable(int remainingHits)
    {
        var durablePosition = remainingHits / MaxDurableValue;
        var colorsValue = 1 - Mathf.Clamp(durablePosition, 0, 1);
        _spriteRenderer.color = new Color(colorsValue, colorsValue, colorsValue);
    }

    #endregion

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private const float MaxDurableValue = 5f;
}
