using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWithBonus : DecoratedBlock
{
    public BlockWithBonus(Bonuses blockBonus, IBonusManager bonusManager, IDecoratedBlock decoratedBlock) : base(decoratedBlock)
    {
        BonusManager = bonusManager;

        _blockWithBonusView = View.GetComponent<IBlockWithBonusView>();

        _blockBonus = blockBonus;
        _blockWithBonusView.SetBonus(_blockBonus);

        _decoratedBlock.Destroyed += OnDestroyed;
    }

    private void OnDestroyed(object sender, EventArgs eventArgs)
    {
        BonusManager.DropBonus(_blockBonus, View.transform.position);
    }

    private IBlockWithBonusView _blockWithBonusView;
    private Bonuses _blockBonus;

    private readonly IBonusManager BonusManager;
}
