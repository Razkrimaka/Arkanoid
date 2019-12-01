using System;
using System.Collections.Generic;
using UnityEditor;
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
        _blockFactory = new BlockFactory(_levelRoot, _bonusManager);
        _scoreController = new ScoreController(_levelRoot);
        _gameModel = new GameModel(_player, _ballController, _inputController, _levelConfiguration, _controllerConfig, _gameCicle, _bonusManager, _blockFactory, _scoreController);
        _wallPack = Resources.Load<WallPack>("Configs/WallPack");
        

        foreach(var wallConfig in _levelConfiguration.Walls)
        {
            var randomIndex = UnityEngine.Random.Range(0, wallConfig.ApprovedWalls.Length);
            var template = _wallPack.GetWall(wallConfig.ApprovedWalls[randomIndex]);
            var wall = GameObject.Instantiate(template, _levelRoot.Transform);
            wall.transform.position = wallConfig.Placeholder;
            _walls.Add(wall);
        }

        var gameEndTemplate = Resources.Load<GameObject>("Prefabs/LevelEnd");
        var gameEndInstance = GameObject.Instantiate(gameEndTemplate, _levelRoot.Transform, true);
        gameEndInstance.transform.position = _levelConfiguration.LevelEndPlaceholder;

        _gameModel.TimeChanged += OnRemainingTimeChanged;
        _gameModel.GameOver += OnGameOver;
    }

    private void OnGameOver(object sender, GameOverReasons reason)
    {
        _gameCicle.Pause = true;
        _ballController.Stop();

        string windowBody = string.Empty;
        string[] buttonTexts = null;
        ButtonCommands[] buttonCommands = null;
        
        switch (reason)
        {
            case GameOverReasons.Time:
                windowBody = "У вас закончилось время!";
                buttonTexts = new string[]
                {
                    "Заново",
                    "Закончить игру"
                };
                buttonCommands = new ButtonCommands[]
                {
                    ButtonCommands.Retry,
                    ButtonCommands.Close
                };
                break;
            case GameOverReasons.LoseBall:
                windowBody = "Вы проиграли. Попробовать снова?";
                buttonTexts = new string[]
                {
                    "Заново",
                    "Закончить игру"
                };
                buttonCommands = new ButtonCommands[]
                {
                    ButtonCommands.Retry,
                    ButtonCommands.Close
                };
                break;
            case GameOverReasons.Win:
                windowBody = "Поздравляем! Вы выиграли. Следующий уровень?";
                buttonTexts = new string[]
                {
                    "Следующий",
                    "Закончить игру"
                };
                buttonCommands = new ButtonCommands[]
                {
                    ButtonCommands.Next,
                    ButtonCommands.Close
                };
                break;
        }

        var dialog = UIManager.Show(WindowID.Dialog, windowBody, buttonTexts, buttonCommands);

        dialog.WindowClosed += OnDialogClosed;
    }

    private void OnDialogClosed(object sender, ButtonCommands closeResult)
    {
        switch (closeResult)
        {
            case ButtonCommands.Close:
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                break;
            case ButtonCommands.Next:
                Debug.Log("Следующий уровень");
                break;
            case ButtonCommands.Retry:
                Debug.Log("Сначала");
                break;
        }
    }

    private void OnRemainingTimeChanged(object sender, TimeSpan timeSpan)
    {
        _timePanelController.SetTime(timeSpan);
    }

#endregion

    public Gameplay(IUIManager uiManager)
    {
        UIManager = uiManager;
    }

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
    private IBonusManager _bonusManager;
    private ITimePanelController _timePanelController;
    private IFactory<Vector3, IBlock> _blockFactory;
    private IScoreController _scoreController;

    private readonly IUIManager UIManager;
}
