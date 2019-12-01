using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : IFactory<Vector3, IBlock>
{
    #region IFactory

    public IBlock Create(Vector3 config)
    {
        var prefabName = "Prefabs/BlockView";

        var durability = Random.Range(0, 3);

        var baseBlock = new BaseBlock(prefabName, LevelRoot, config);
        var result = default(DecoratedBlock);

        if (durability>0)
        {
            result = new DurableBlock(durability, baseBlock);
        }
        else
        {
            result = new SimpleBlock(baseBlock);
        }

        return result;
    }

    #endregion

    public BlockFactory(ILevelRoot levelRoot)
    {
        LevelRoot = levelRoot;
    }

    private readonly ILevelRoot LevelRoot;
}
