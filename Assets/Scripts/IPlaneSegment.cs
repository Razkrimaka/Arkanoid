using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPartOfPlane
{
    Vector2 Normal { get; }
    void IsEntered(Vector2 position);

    Vector2 MiddlePoint { get; }
}
