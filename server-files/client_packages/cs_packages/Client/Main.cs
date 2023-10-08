using RAGE;
using RAGE.Elements;
using RAGE.Game;
using RAGE.Ui;


public class Main : Events.Script
{
    public static HtmlWindow openedWindow;
    public static Camera currentCamera;
    public Main()
    {
        Events.OnPlayerReady += OnPlayerReady;
        Events.OnPlayerSpawn += OnPlayerSpawn;
    }
    public void OnPlayerReady()
    {
        Chat.Output("Добро пожаловать!");
    }
    public void OnPlayerSpawn(Events.CancelEventArgs cancel)
    {
        openedWindow = new HtmlWindow("package://cef/auth/index.html");
        openedWindow.Active = true;
        Cursor.ShowCursor(true, true);
        Chat.Activate(false);
        Ui.DisplayRadar(false);
        
    }
}