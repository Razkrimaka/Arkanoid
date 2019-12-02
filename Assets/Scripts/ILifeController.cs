using System;

public interface ILifeController
{
    event EventHandler GameOver;
    void DecreaseHP();
    void IncreaseHP();
    void GoToStart();
}
