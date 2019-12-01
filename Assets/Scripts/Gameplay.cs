using System;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : IGameplay
{
    #region IGameplay

    public void CreateLevel(string levelId)
    {
        _gameCicle = GameObject.Instantiate(Resources.Load<GameCicle>("Prefabs/GameCicle"));
        _levelRoot = GameObject.Instantiate(Resources.Load<LevelRoot>("Prefabs/LevelRoot"));
        _inputController = new KeyboardInput(_gameCicle);        
        _controllerConfig = GameObject.Instantiate(Resources.Load<ControllerConfig>("Configs/InputConfig"));
        _levelConfiguration = GameObject.Instantiate(Resources.Load<LevelConfig>($"Prefabs/Levels/{levelId}"));
        _player = new Player("Prefabs/PlayerView", _levelRoot, _levelConfiguration.PlayerStartPosition);
        _ballController = new BallController("Prefabs/BallView", _levelRoot, _levelConfiguration.BallStartPosition);
        _bonusManager = new BonusManager();
        _timePanelController = new TimePanelController(_levelRoot);
        _gameModel = new GameModel(_player, _ballController, _inputController, _levelConfiguration, _controllerConfig, _gameCicle, _bonusManager);
        _wallPack = Resources.Load<WallPack>("Configs/WallPack");
        _blockFactory = new BlockFactory(_levelRoot, _bonusManager);

        foreach (var blockPlaceholder in _levelConfiguration.BlocksPlaceholders)
        {
            var block = _blockFactory.Create(blockPlaceholder);
            _blocks.Add(block);
        }

        foreach(var wallConfig in _levelConfiguration.Walls)
        {
            var randomIndex = UnityEngine.Random.Range(0, wallConfig.ApprovedWalls.Length);
            var template = _wallPack.GetWall(wallConfig.ApprovedWalls[randomIndex]);
            var wall = GameObject.Instantiate(template, _levelRoot.Transform);
            wall.transform.position = wallConfig.Placeholder;
            _walls.Add(wall);
        }

        _gameModel.TimeChanged += OnRemainingTimeChanged;
        _gameModel.GameOver += OnGameOver;
    }

    private void OnGameOver(object sender, GameOverReasons reason)
    {
        _gameCicle.Pause = true;
        Debug.LogError("Конец игры!");
    }

    private void OnRemainingTimeChanged(object sender, TimeSpan timeSpan)
    {
        _timePanelController.SetTime(timeSpan);
    }

    #endregion

    public Gameplay()
    {
    }

    private List<IBlock> _blocks = new List<IBlock>();
    private List<IReleasable> _walls = new List<IReleasable>();


    private IInputController _inputController;
    private IControllerConfig _controllerConfig;
    private IGameCicle _gameCicle;
    private IPlayer _player;
    private IBallController _ballController;
    private ILevelRoot _levelRoot;
    private ILevelConfiguration _levelConfiguration;
    private IGameModel _gameModel;
    private IWallPack _wallPack;
    private IFactory<Vector3, IBlock> _blockFactory;
    private IBonusManager _bonusManager;
    private ITimePanelController _timePanelController;
}
