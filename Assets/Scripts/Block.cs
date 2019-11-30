using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block :  IBlock
{
    public event EventHandler Destroyed;

    public abstract void Hit();

    protected Block(string prefabName, ILevelRoot levelRoot, Vector3 position)
    {
        _blockView = GameObject.Instantiate(Resources.Load<BlockView>(prefabName), levelRoot.Transform, true);
        _blockView.transform.position = position;
    }

    protected readonly BlockView _blockView;
}
