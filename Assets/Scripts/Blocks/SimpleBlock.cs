using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SimpleBlock : DecoratedBlock
{
    public SimpleBlock(IDecoratedBlock decoratedBlock) : base(decoratedBlock)
    {
        View.Hit += OnHit;
    }

    private void OnHit(object sender, System.EventArgs e)
    {
        DestroyBlock();
    }
}
