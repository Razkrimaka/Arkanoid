public class GameModel : IGameModel
{
    public GameModel
        (IPlayer player,
        IInputController input,
        ILevelConfiguration levelConfiguration,
        IControllerConfig controllerConfig)
    {
        Player = player;
        Input = input;
        LevelConfiguration = levelConfiguration;
        ControllerConfig = controllerConfig;

        UnityEngine.Debug.LogError($"Pos: {LevelConfiguration.PlayerStartPosition}");
        Player.SetInitializePosition(LevelConfiguration.PlayerStartPosition);


        Input.MoveLeft += OnInputMoveLeft;
        Input.MoveRight += OnInputMoveRight;
    }

    private void OnInputMoveRight(object sender, float duration)
    {
        CurrentPlayerPosition += duration * ControllerConfig.MoveSensity;
    }

    private void OnInputMoveLeft(object sender, float duration)
    {
        CurrentPlayerPosition -= duration * ControllerConfig.MoveSensity;
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

    private float _currentPlayerPosition;

    private readonly IPlayer Player;
    private readonly IInputController Input;
    private readonly ILevelConfiguration LevelConfiguration;
    private readonly IControllerConfig ControllerConfig;
}
