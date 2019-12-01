using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDecoratedBlock
{
    BlockView View { get; }

    void DestroyBlock();
}
