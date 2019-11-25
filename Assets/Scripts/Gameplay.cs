using UnityEngine;

public class Gameplay : IGameplay
{
    #region IGameplay

    public void CreateLevel(string levelId)
    {
        _gameCicle = GameObject.Instantiate(Resources.Load<GameCicle>("Prefabs/GameCicle"));
        _gameplayCanvas = GameObject.Instantiate(Resources.Load<GameplayCanvas>("Prefabs/GameplayCanvas"));
        _inputController = new KeyboardInput(_gameCicle);        
        _controllerConfig = GameObject.Instantiate(Resources.Load<ControllerConfig>("Configs/InputConfig"));
        _player = new Player("Prefabs/PlayerView", _gameplayCanvas);
        _levelConfiguration = GameObject.Instantiate(Resources.Load<LevelConfig>($"Prefabs/Levels/{levelId}"));
        _gameModel = new GameModel(_player, _inputController, _levelConfiguration, _controllerConfig);
    }

    #endregion

    public Gameplay()
    {

    }


    private IInputController _inputController;
    private IControllerConfig _controllerConfig;
    private IGameCicle _gameCicle;
    private IPlayer _player;
    private IGameplayCanvas _gameplayCanvas;
    private ILevelConfiguration _levelConfiguration;
    private IGameModel _gameModel;
}
