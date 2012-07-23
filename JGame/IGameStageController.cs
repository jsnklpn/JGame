using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGame
{
    interface IGameStageController
    {
        void ChangeStage(int stageNum);
        GameVars GetGameVars();
        void Exit();
    }
}
