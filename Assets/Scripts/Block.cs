using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block :  IBlock
{
    public Block(string prefabName, IGameplayCanvas gameplayCanvas, Vector3 position)
    {
        _blockView = GameObject.Instantiate(Resources.Load<BlockView>(prefabName), gameplayCanvas.CanvasTransform, true);
        _blockView.transform.position = position;
        _blockView.DrawNormals();
    }

    private readonly BlockView _blockView;
}
