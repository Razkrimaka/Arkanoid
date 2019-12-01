using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : IGameModel
{
    #region IReleasable

    public void Release()
    {
        SetListeners(false);
    }

    #endregion

    #region IGameModel 

    public event EventHandler<TimeSpan> TimeChanged;

    #endregion

    public GameModel
        (IPlayer player,
        IBallController ballController,
        IInputController input,
        ILevelConfiguration levelConfiguration,
        IControllerConfig controllerConfig,
        IGameCicle gameCicle,
        IBonusManager bonusManager)
    {
        Player = player;
        BallController = ballController;
        Input = input;
        LevelConfiguration = levelConfiguration;
        ControllerConfig = controllerConfig;
        GameCicle = gameCicle;
        BonusManager = bonusManager;

        SetListeners(true);

        GoToStart();
    }

    private void SetListeners(bool listeners)
    {
        if (listeners)
        {
            Input.MoveLeft += OnInputMoveLeft;
            Input.MoveRight += OnInputMoveRight;

            BonusManager.BonusPicked += ProcessBonus;

            GameCicle.Tick += OnTick;
        }
        else
        {
            Input.MoveLeft += OnInputMoveLeft;
            Input.MoveRight += OnInputMoveRight;

            GameCicle.Tick -= OnTick;
        }

        void OnInputMoveRight(object sender, float duration)
        {
            CurrentPlayerPosition += duration * ControllerConfig.MoveSensity;
        }

        void OnInputMoveLeft(object sender, float duration)
        {
            CurrentPlayerPosition -= duration * ControllerConfig.MoveSensity;
        }
    }

    private void ProcessBonus(object sender, Bonuses bonus)
    {
        switch (bonus)
        {
            case Bonuses.Time:
                RemainingTime += TimeSpan.FromSeconds(LevelConfiguration.BonusTime);
                break;
        }
    }

    private void OnTick(object sender, float duration)
    {
        RemainingTime -= TimeSpan.FromSeconds(duration);
    }

    private void GoToStart ()
    {
        Player.GoToStart();
        _currentPlayerPosition = LevelConfiguration.PlayerStartPosition.x;
        BallController.GoToStart(Vector2.one * BallEnergy);
        RemainingTime = TimeSpan.FromSeconds(600);
    }

    private float CurrentPlayerPosition 
    {
        get => _currentPlayerPosition;
        set
        {
            _currentPlayerPosition = value;
            Player.Move(value);
        }
    }

    private TimeSpan RemainingTime
    {
        get => _remainingTime;
        set
        {
            _remainingTime = value;
            TimeChanged?.Invoke(this, _remainingTime);
        }
    }



    private float _currentPlayerPosition;
    private TimeSpan _remainingTime;
    private const float BallEnergy = 400f;

    private List<IBlock> _blocks = new List<IBlock>();

    private readonly IPlayer Player;
    private readonly IBallController BallController;
    private readonly IInputController Input;
    private readonly ILevelConfiguration LevelConfiguration;
    private readonly IControllerConfig ControllerConfig;
    private readonly IGameCicle GameCicle;
    private readonly IBonusManager BonusManager;
}
