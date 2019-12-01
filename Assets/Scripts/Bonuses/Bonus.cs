using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : IBonus
{
    #region IBonus

    public event EventHandler Picked;
    public event EventHandler Over;

    #endregion

    public Bonus(Bonuses bonusId, Vector3 position, BonusView view)
    {
        view.SetBonus(bonusId);
        view.Throw(position, GetThrowedForce());

        view.Collision += OnCollision;
    }

    private void OnCollision(object sender, string tag)
    {
        switch (tag)
        {
            case "Player":
                Picked?.Invoke(this, EventArgs.Empty);
                break;
            case "Finish":
                Over?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private Vector3 GetThrowedForce ()
    {
        var randomVector = UnityEngine.Random.insideUnitSphere;
        var modifiedVector = new Vector3(randomVector.x, Mathf.Abs(randomVector.y), 0);
        return modifiedVector * ThrowForce;
    }


    private const float ThrowForce = 5000f;
}
