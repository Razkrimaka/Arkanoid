using System;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : IBonusManager
{
    #region IBonusManager

    public event EventHandler<Bonuses> BonusPicked;

    public void DropBonus(Bonuses bonusId, Vector2 position)
    {
        // TODO: заменить пулом объектов
        var template = Resources.Load<BonusView>("Prefabs/BonusView");
        var instance = GameObject.Instantiate(template);

        IBonus bonus = new Bonus(bonusId, position, instance);
        _bonuses.Add(bonus);
        bonus.Picked += OnBonusPicked;
        bonus.Over += OnBonusOver;

        void OnBonusPicked(object sender, EventArgs eventArgs)
        {
            bonus.Picked -= OnBonusPicked;
            BonusPicked?.Invoke(this, bonusId);
            Release(bonus);
        }

        void OnBonusOver(object sender, EventArgs eventArgs)
        {
            bonus.Over -= OnBonusOver;
            Release(bonus);
        }
    }

    public void Stop()
    {
        foreach(var bonus in _bonuses)
        {
            bonus.Stop();
        }
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        foreach (var bonus in _bonuses)
        {
            bonus.Release();
        }
        _bonuses.Clear();
    }

    #endregion

    private void Release (IBonus bonus)
    {
        bonus.Release();
        _bonuses.Remove(bonus);
    }

    private List<IBonus> _bonuses = new List<IBonus>();
}
