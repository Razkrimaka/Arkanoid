using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratedBlock :  IDecoratedBlock
{
    #region IBlock

    public virtual event EventHandler Destroyed;

    #endregion

    #region IDecoratedBlock

    public BlockView View => _decoratedBlock.View;

    public void DestroyBlock()
    {
        _decoratedBlock.DestroyBlock();
    }

    #endregion

    #region IReleasable 

    public void Release ()
    {
        _decoratedBlock.Release();
        _decoratedBlock = null;
    }

    #endregion

    public DecoratedBlock(IDecoratedBlock decoratedBlock)
    {
        _decoratedBlock = decoratedBlock;

        _decoratedBlock.Destroyed += OnDecoratedBlockDestroyed;

        void OnDecoratedBlockDestroyed(object sender, EventArgs eventArgs)
        {
            Destroyed?.Invoke(this, eventArgs);           
        }
    }

    protected IDecoratedBlock _decoratedBlock;
}
