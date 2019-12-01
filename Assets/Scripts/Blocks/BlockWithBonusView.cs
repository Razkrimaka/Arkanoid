using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWithBonusView : MonoBehaviour, IBlockWithBonusView
{
    #region IBlockWithBonus

    public void SetBonus(Bonuses bonusId)
    {
        var spriteName = $"Sprites/{bonusId}";
        var sprite = Resources.Load<Sprite>(spriteName);
        _spriteBonus.sprite = sprite;
    }

    #endregion

    [SerializeField]
    private SpriteRenderer _spriteBonus;
}
