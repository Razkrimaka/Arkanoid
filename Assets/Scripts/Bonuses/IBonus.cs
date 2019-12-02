using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonus : IReleasable
{
    event EventHandler Picked;
    event EventHandler Over;

    void Stop();
}
