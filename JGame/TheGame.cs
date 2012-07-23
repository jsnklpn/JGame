using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace JGame
{
    // This class handles all the game logic and 
    // updates all actors on a fixed interval.
    // It DOES NOT draw anything -- it calls IDisplay.Draw() when needed
    class TheGame : IGame, IGameStageController
    {
        private GameVars _gameVars;
        private Random _rand;
        private List<Object2D> _allActors;
        private bool _bGameIsRunning;
        private IDisplay _view;
        private Size _displaySize;

        private IGameStage[] _gameStages;
        private int _currentStageIndex;

        public TheGame(IDisplay view, Size displaySize)
        {
            _view = view;
            _rand = new Random();
            _allActors = new List<Object2D>();
            _gameVars = new GameVars();
            _bGameIsRunning = false;
            _displaySize = displaySize;

            SetUpGame();
        }

        #region IGame interface methods
        public bool IsGameRunning()
        {
            return _bGameIsRunning;
        }

        public void KeyHandler(Keys key, KeyState state)
        {
            // get current stage and pass it the key
            _gameStages[_currentStageIndex].KeyHandler(key, state);
        }

        public void ChangeDisplaySize(Size displaySize)
        {
            _displaySize = displaySize;
        }

        public void Draw(Graphics graphics, float interp)
        {
            // get current stage and paint it
            _gameStages[_currentStageIndex].Draw(graphics, interp);
        }
        #endregion

        #region IGameStageController interface methods

        public void Exit()
        {
            _view.Exit();
        }

        public void ChangeStage(int stageNum)
        {
            if (stageNum >= 0 && stageNum < _gameStages.Count())
                _currentStageIndex = stageNum;
        }

        public GameVars GetGameVars()
        {
            return _gameVars;
        }

        #endregion

        #region Game init and setup
        // Set things up for the start of the game -- called in game constructor
        private void SetUpGame()
        {
            // Start things off with 1 stage...
            _gameStages = new IGameStage[1];

            //_gameStages[0] = new MenuStage();
            _gameStages[0] = new LevelStage(this);

            _currentStageIndex = 0;
        }
        #endregion

        #region Game loop
        public void Start()
        {
            if (!_bGameIsRunning)
            {
                _bGameIsRunning = true;
                // start the game update thread (fixed interval)
                System.Threading.ThreadPool.QueueUserWorkItem(GameThread);
            }
        }

        private void GameThread(object state)
        {
            const int TICKS_PER_SECOND = 30; // game update rate -- This changes the game speed.
            const int SKIP_TICKS = 1000 / TICKS_PER_SECOND;
            const int MAX_FRAMESKIP = 5;

            int nextGameTick = Environment.TickCount;
            int loops;
            float interp;

            // GameLoop:
            // This loop will update the game at a fixed frequency, but allow for maximum fps
            while (_bGameIsRunning)
            {
                loops = 0;
                while (Environment.TickCount > nextGameTick && loops < MAX_FRAMESKIP)
                {
                    UpdateGame();
                    nextGameTick += SKIP_TICKS;
                    loops++;
                }

                interp = ((float)(Environment.TickCount + SKIP_TICKS - nextGameTick)) /
                         ((float)SKIP_TICKS);

                _view.Draw(interp);
            }
        }
        #endregion

        #region Game update methods
        // called TICKS_PER_SECOND times per second (25)
        private void UpdateGame()
        {
            _gameStages[_currentStageIndex].Update();
        }


        #endregion
    }
}
