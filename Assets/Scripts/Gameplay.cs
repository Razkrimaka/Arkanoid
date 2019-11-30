﻿using System.Collections.Generic;
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
        _levelConfiguration = GameObject.Instantiate(Resources.Load<LevelConfig>($"Prefabs/Levels/{levelId}"));
        _player = new Player("Prefabs/PlayerView", _gameplayCanvas, _levelConfiguration.PlayerStartPosition);
        _ballController = new BallController("Prefabs/BallView", _gameplayCanvas, _levelConfiguration.BallStartPosition);
        _gameModel = new GameModel(_player, _ballController, _inputController, _levelConfiguration, _controllerConfig, _gameCicle);
        _wallPack = Resources.Load<WallPack>("Configs/WallPack");

        foreach (var blockPlaceholder in _levelConfiguration.BlocksPlaceholders)
        {
            var block = new Block("Prefabs/BlockView", _gameplayCanvas, blockPlaceholder);
            _blocks.Add(block);
        }

        foreach(var wallConfig in _levelConfiguration.Walls)
        {
            var randomIndex = Random.Range(0, wallConfig.ApprovedWalls.Length);
            var template = _wallPack.GetWall(wallConfig.ApprovedWalls[randomIndex]);
            var wall = GameObject.Instantiate(template, _gameplayCanvas.Transform);
            wall.transform.position = wallConfig.Placeholder;
            _walls.Add(wall);
        }
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
    private ILevelRoot _gameplayCanvas;
    private ILevelConfiguration _levelConfiguration;
    private IGameModel _gameModel;
    private IWallPack _wallPack;
}
