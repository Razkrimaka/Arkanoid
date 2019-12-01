using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : IFactory<Vector3, IBlock>
{
    #region IFactory

    public IBlock Create(Vector3 config)
    {
        var prefabName = "Prefabs/BlockView";
        var baseBlock = new BaseBlock(prefabName, LevelRoot, config);
        IDecoratedBlock decoratedObject = baseBlock;

        foreach (var decorator in BuildStages())
        {
            decoratedObject = decorator(decoratedObject);
        }


        return decoratedObject;
    }

    #endregion

    private IEnumerable<Func<IDecoratedBlock, IDecoratedBlock>> BuildStages ()
    {
        yield return DecorateDurability;
        yield return DecorateBonus;
    }

    private IDecoratedBlock DecorateDurability (IDecoratedBlock block)
    {
        var result = default(DecoratedBlock);
        var durability = UnityEngine.Random.Range(0, 2);

        if (durability > 0)
        {
            result = new DurableBlock(durability, block);
        }
        else
        {
            result = new SimpleBlock(block);
        }

        return result;
    }
    private IDecoratedBlock DecorateBonus(IDecoratedBlock block)
    {
        var result = block;
        var randomValue = UnityEngine.Random.Range(0, 100);
        var bonusArray = Enum.GetValues(typeof(Bonuses));

        if (randomValue > BonusRate)
        {
            var bonus = (Bonuses)UnityEngine.Random.Range(0, bonusArray.Length);
            result = new BlockWithBonus(bonus, BonusManager, block);
        }

        return result;
    }

    public BlockFactory(ILevelRoot levelRoot, IBonusManager bonusManager)
    {
        LevelRoot = levelRoot;
        BonusManager = bonusManager;
    }

    private readonly ILevelRoot LevelRoot;
    private readonly IBonusManager BonusManager;
    private const int BonusRate = 60;
}
