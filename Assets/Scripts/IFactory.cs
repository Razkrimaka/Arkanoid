using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<TConfig, TItem>
{
    TItem Create(TConfig config);
}
