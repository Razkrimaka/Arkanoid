using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DurableBlock : DecoratedBlock
{
    public DurableBlock(int durability, IDecoratedBlock decoratedBlock) : base(decoratedBlock)
    {
        _durableView = View.GetComponent<IDurableView>();
        Durability = durability;        

        View.Hit += OnHit;
    }

    private void OnHit(object sender, System.EventArgs e)
    {
        if (Durability > 0)
        {
            Durability--;
        }
        else
        {
            DestroyBlock();
        }
    }

    private int Durability
    {
        get
        {
            return _durability;
        }
        set
        {
            _durability = value;
            _durableView.SetDurable(value);
        }
    }
    private int _durability;

    private IDurableView _durableView;
}
