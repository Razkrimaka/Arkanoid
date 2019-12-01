using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDecoratedBlock : IBlock
{
    BlockView View { get; }

    void DestroyBlock();
}
