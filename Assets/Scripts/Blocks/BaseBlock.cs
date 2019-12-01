using System;
using UnityEngine;

public class BaseBlock : IBlock, IDecoratedBlock
{
    #region IBlock

    public event EventHandler Destroyed;

    #endregion

    #region IDecoratedBlock

    public BlockView View { get; private set; }

    public void DestroyBlock()
    {
        View.gameObject.SetActive(false);
        Destroyed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    public BaseBlock(string prefabName, ILevelRoot levelRoot, Vector3 position)
    {
        var template = Resources.Load<BlockView>(prefabName);
        View = GameObject.Instantiate(template, levelRoot.Transform, true);
        View.transform.position = position;
    }
}
