using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject.Managers
{
    public abstract class GameState
    {
        public abstract void HandleInput();
        public abstract void Update();
        public abstract void Render();
    }
}
