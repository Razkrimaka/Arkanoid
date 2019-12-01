using System;
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
        bonus.Picked += OnBonusPicked;
        bonus.Over += OnBonusOver;

        void OnBonusPicked(object sender, EventArgs eventArgs)
        {
            bonus.Picked -= OnBonusPicked;

            BonusPicked?.Invoke(this, bonusId);
        }

        void OnBonusOver(object sender, EventArgs eventArgs)
        {
            bonus.Over -= OnBonusOver;
            ReleaseView(instance);
        }
    }

    #endregion

    private void ReleaseView(BonusView bonusView)
    {
        // TODO: заготовка под пулл объектов
    }
}
