using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonusView
{
    event EventHandler<string> Collision;

    void SetBonus(Bonuses bonusId);
}
