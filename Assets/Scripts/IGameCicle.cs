using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameCicle : IReleasable
{
    event EventHandler<float> Tick;

    bool Pause { get; set; }
}
