using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratedBlock : IBlock, IDecoratedBlock
{
    #region IBlock

    public event EventHandler Destroyed;

    #endregion

    #region IDecoratedBlock

    public BlockView View => _decoratedBlock.View;

    public void DestroyBlock()
    {
        _decoratedBlock.DestroyBlock();
    }

    #endregion

    public DecoratedBlock(IDecoratedBlock decoratedBlock)
    {
        _decoratedBlock = decoratedBlock;
    }

    protected IDecoratedBlock _decoratedBlock;
}
