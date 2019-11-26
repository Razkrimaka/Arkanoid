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

    public GameModel
        (IPlayer player,
        IBallController ballController,
        IInputController input,
        ILevelConfiguration levelConfiguration,
        IControllerConfig controllerConfig,
        IGameCicle gameCicle)
    {
        Player = player;
        BallController = ballController;
        Input = input;
        LevelConfiguration = levelConfiguration;
        ControllerConfig = controllerConfig;
        GameCicle = gameCicle;

        SetListeners(true);

        GoToStart();
    }

    private void SetListeners(bool listeners)
    {
        if (listeners)
        {
            Input.MoveLeft += OnInputMoveLeft;
            Input.MoveRight += OnInputMoveRight;

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

    private void OnTick(object sender, float duration)
    {
        CurrentBallPosition = _currentBallPosition + _ballMoveDirection * _ballSpeed;
    }

    private void GoToStart ()
    {
        Player.GoToStart();
        _currentPlayerPosition = LevelConfiguration.PlayerStartPosition.x;
        BallController.GoToStart();
        _currentBallPosition = LevelConfiguration.BallStartPosition;

        foreach (var blockPlaceholder in LevelConfiguration.BlocksPlaceholders)
        {

        }
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
    private Vector2 CurrentBallPosition
    {
        get => _currentBallPosition;
        set
        {
            _currentBallPosition = value;
            BallController.Move(_currentBallPosition);
        }
    }

    private Vector2 _ballMoveDirection = Vector2.one;
    private float _ballSpeed = 2f;

    private float _currentPlayerPosition;
    private Vector2 _currentBallPosition;

    private List<IBlock> _blocks = new List<IBlock>();

    private readonly IPlayer Player;
    private readonly IBallController BallController;
    private readonly IInputController Input;
    private readonly ILevelConfiguration LevelConfiguration;
    private readonly IControllerConfig ControllerConfig;
    private readonly IGameCicle GameCicle;
}
