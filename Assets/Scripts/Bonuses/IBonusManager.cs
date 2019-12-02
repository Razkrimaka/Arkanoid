using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonusManager : IReleasable
{
    event EventHandler<Bonuses> BonusPicked;

    void DropBonus(Bonuses bonusId, Vector2 position);
    void Stop();
}
