using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using HDProject;
using SplashKitSDK;

public class Program
{
    private static Window window;

    public static void Main()
    {
        new Window("HDProject", 1400, 900);


        GameManager gameManager = new GameManager();
        //CollissionManager collissionManager = new CollissionManager(gameManager);

        do
        {
            SplashKit.ProcessEvents();

            gameManager.Update();
            gameManager.Render();

            SplashKit.RefreshScreen(60);

        } while (!SplashKit.WindowCloseRequested("HDProject"));
        {
            SplashKit.CloseWindow("HDProject");
        }
    }
}
