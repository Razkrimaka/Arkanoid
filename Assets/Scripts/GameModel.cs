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
    public event EventHandler<GameOverReasons> GameOver;

    #endregion

    public GameModel
        (IPlayer player,
        IBallController ballController,
        IInputController input,
        ILevelConfiguration levelConfiguration,
        IControllerConfig controllerConfig,
        IGameCicle gameCicle,
        IBonusManager bonusManager,
        IFactory<Vector3, IBlock> blockFactory,
        IScoreController scoreController)
    {
        Player = player;
        BallController = ballController;
        Input = input;
        LevelConfiguration = levelConfiguration;
        ControllerConfig = controllerConfig;
        GameCicle = gameCicle;
        BonusManager = bonusManager;
        BlockFactory = blockFactory;
        ScoreController = scoreController;
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
            BallController.LoseBall += OnLoseBall;
            BallController.TouchPlatform += OnTouchPlatform;

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

    private void OnTouchPlatform(object sender, EventArgs e)
    {
        ScoreController.ResetScoreSequence();
    }

    private void OnLoseBall(object sender, EventArgs eventArgs)
    {
        ThrowGameOver(GameOverReasons.LoseBall);
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
        CreateBlocks(LevelConfiguration);
        ScoreController.GoToStart();
        Player.GoToStart();
        _currentPlayerPosition = LevelConfiguration.PlayerStartPosition.x;
        BallController.GoToStart(Vector2.one * BallEnergy);
        RemainingTime = TimeSpan.FromSeconds(LevelConfiguration.StartTime);
    }

    private void CreateBlocks(ILevelConfiguration config)
    {
        if (_blocks!= null)
        {
            foreach (var block in _blocks)
            {
                block.Release();
            }
            _blocks.Clear();
        }
        else
        {
            _blocks = new List<IBlock>();
        }

        _currentBlocksCount = 0;

        foreach (var blockPlaceholder in config.BlocksPlaceholders)
        {
            var block = BlockFactory.Create(blockPlaceholder);
            _blocks.Add(block);
            block.Destroyed += OnBlockDestroy;
        }

        CurrentBlocksCount = _blocks.Count;
    }

    private void OnBlockDestroy(object sender, EventArgs eventArgs)
    {
        CurrentBlocksCount--;

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
    private int CurrentBlocksCount
    {
        get => _currentBlocksCount;
        set
        {
            _currentBlocksCount = value;
            ScoreController.IncrementPoint();
            if (_currentBlocksCount==0)
            {
                ThrowGameOver(GameOverReasons.Win);
            }
        }
    }

    private TimeSpan RemainingTime
    {
        get => _remainingTime;
        set
        {
            _remainingTime = value;
            if (_remainingTime.TotalSeconds>=0)
            {
                TimeChanged?.Invoke(this, _remainingTime);
            }
            else
            {
                ThrowGameOver(GameOverReasons.Time);
            }           
        }
    }

    private void ThrowGameOver (GameOverReasons reason)
    {
        GameOver?.Invoke(this, reason);
    }

    private float _currentPlayerPosition;
    private int _currentBlocksCount;
    private TimeSpan _remainingTime;
    private const float BallEnergy = 400f;

    private List<IBlock> _blocks;

    private readonly IPlayer Player;
    private readonly IBallController BallController;
    private readonly IInputController Input;
    private readonly ILevelConfiguration LevelConfiguration;
    private readonly IControllerConfig ControllerConfig;
    private readonly IGameCicle GameCicle;
    private readonly IBonusManager BonusManager;
    private readonly IFactory<Vector3, IBlock> BlockFactory;
    private readonly IScoreController ScoreController;
}
