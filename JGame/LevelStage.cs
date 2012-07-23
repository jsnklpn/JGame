using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JGame
{
    class LevelStage : IGameStage
    {
        protected IGameStageController _stageController;
        protected IControllable _player1, _player2; // change this to a better subclass (which uses a 2d object)
        protected List<Object2D> _allActors;
        protected int _tick;

        public LevelStage(IGameStageController stageController)
        {
            _stageController = stageController;
            _allActors = new List<Object2D>();
            _player1 = _player2 = null;
            _tick = 0;

            //PlayerObject p = new PlayerObject(JGame.Properties.Resources.default_texture);
            //_player1 = p;
            //_allActors.Add(p);
        }

        public void Draw(System.Drawing.Graphics graphics, float interp)
        {
            _allActors.ForEach(o => o.Draw(graphics, interp));
        }

        public void Update()
        {
            _allActors.ForEach(o => o.Move());
            _tick++;

            //if (_tick % 8 == 0)
            //{
            //    NPCObject npc = new NPCObject(Properties.Resources.g64, 100);
            //    npc.location.X = 0f;
            //    npc.location.Y = 100f;
            //    npc.MaxVelocity = 10f;
            //    npc.angleVelocity = 0.2f;
            //    npc.FollowSineWave(false, 15, 5);

            //    _allActors.Add(npc);
            //}
        }

        public void KeyHandler(Keys key, KeyState state)
        {
            GameVars gameVars = _stageController.GetGameVars();

            //////////////
            // PLAYER 1 //
            //////////////
            if (key == gameVars.PLAYER1_START)
            {
                if (_player1 != null)
                    _player1.Start(state);
            }
            else if (key == gameVars.PLAYER1_UP)
            {
                if (_player1 != null)
                    _player1.Up(state);
            }
            else if (key == gameVars.PLAYER1_DOWN)
            {
                if (_player1 != null)
                    _player1.Down(state);
            }
            else if (key == gameVars.PLAYER1_LEFT)
            {
                if (_player1 != null)
                    _player1.Left(state);
            }
            else if (key == gameVars.PLAYER1_RIGHT)
            {
                if (_player1 != null)
                    _player1.Right(state);
            }
            else if (key == gameVars.PLAYER1_BUTTON1)
            {
                if (_player1 != null)
                    _player1.Button1(state);
            }
            else if (key == gameVars.PLAYER1_BUTTON2)
            {
                if (_player1 != null)
                    _player1.Button2(state);
            }
            //////////////
            // PLAYER 2 //
            //////////////
            else if (key == gameVars.PLAYER2_START)
            {
                if (_player2 != null)
                    _player2.Start(state);
            }
            else if (key == gameVars.PLAYER2_UP)
            {
                if (_player2 != null)
                    _player2.Up(state);
            }
            else if (key == gameVars.PLAYER2_DOWN)
            {
                if (_player2 != null)
                    _player2.Down(state);
            }
            else if (key == gameVars.PLAYER2_LEFT)
            {
                if (_player2 != null)
                    _player2.Left(state);
            }
            else if (key == gameVars.PLAYER2_RIGHT)
            {
                if (_player2 != null)
                    _player2.Right(state);
            }
            else if (key == gameVars.PLAYER2_BUTTON1)
            {
                if (_player2 != null)
                    _player2.Button1(state);
            }
            else if (key == gameVars.PLAYER2_BUTTON2)
            {
                if (_player2 != null)
                    _player2.Button2(state);
            }
            ///////////
            // OTHER //
            ///////////
            else if (key == gameVars.QUIT)
            {
                _stageController.Exit();
            }
        }

        protected void MoveAllActors()
        {
            foreach (Object2D actor in _allActors)
            {
                actor.Move();
            }
        }

        protected void RemoveActorsTaggedForRemoval()
        {
            _allActors.RemoveAll(o => o.doRemoveFromGame);
        }

        public void AddActor(Object2D obj)
        {
            _allActors.Add(obj);
        }

    }
}
