using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace HDProject
{
    public class BackgroundStars
    {

        StarManager starMgr = new StarManager();


        public BackgroundStars()
        { }
       public void Update(bool playermovingforward)
        {
            starMgr.Update();
            starMgr.Acceleration(playermovingforward);
        }


    }
}
