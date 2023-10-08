using Newtonsoft.Json.Linq;
using RAGE;
using RAGE.Elements;
using RAGE.Game;
using RAGE.Ui;
using System;
using System.Collections.Generic;
using System.Text;

public class ServerEvents : Events.Script
{
    public ServerEvents()
    {
        Events.Add("SERVER:CLIENT::REGISTER_USER", OnServerRegisterUser);
        Events.Add("SERVER:CLIENT::LOGIN_USER", OnServerLoginUser);
        Events.Add("SERVER:CLIENT::CREATE_PERSON", OnServerCreatePerson);
        Events.Add("SERVER:CLIENT:UPDATE_SAVED_CUSTOMIZATION", OnUpdateSavedCustomization);
    }
    public void OnServerRegisterUser(object[] args)
    {
        bool isExists = (bool)args[0];
        if (isExists) Main.openedWindow.ExecuteJs("document.dispatchEvent(new Event('registerExists'))");
        else
        {
            Main.openedWindow.Destroy();
            Main.currentCamera = new Camera((ushort)Cam.CreateCameraWithParams(Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), -1701.2742f, -1091.0533f, 13.152317f, 0f, 0f, -132.74817f, 70.0f, true, 2), 0);
            Cam.PointCamAtCoord(Main.currentCamera.Id, -1698.8102f, -1093.2312f, 13.152362f);
            Cam.SetCamActive(Main.currentCamera.Id, true);
            Cam.RenderScriptCams(true, false, 0, true, false, 0);
            Chat.Activate(false);
            Main.openedWindow = new HtmlWindow("package://cef/create_person/index.html");
            Main.openedWindow.Active = true;
            Cursor.ShowCursor(true, true);
        }
    }
    public void OnServerLoginUser(object[] args)
    {
        bool notExists = (bool)args[0];
        if (notExists) Main.openedWindow.ExecuteJs("document.dispatchEvent(new Event('loginNotValidData'))");
        else
        {
            Main.openedWindow.Destroy();
            Cursor.ShowCursor(false, false);
            Chat.Activate(true);
            Ui.DisplayRadar(true);
        }

    }
    public void OnServerCreatePerson(object[] args) 
    {
        if (Main.openedWindow != null) Main.openedWindow.Destroy();
        Cursor.ShowCursor(false, false);
        Ui.DisplayRadar(true);
        Chat.Show(true);
        Cam.RenderScriptCams(false, false, 0 , true, false, 0);
        Main.currentCamera = null;
    }
    private void OnUpdateSavedCustomization(object[] args)
    {
        if (RAGE.Elements.Player.LocalPlayer.HasData("CLIENT_CUSTOMIZATION_DATA"))
        {
            string json = RAGE.Elements.Player.LocalPlayer.GetData<string>("CLIENT_CUSTOMIZATION_DATA");
            if (string.IsNullOrEmpty(json)) return;
            dynamic customizationInfo = JObject.Parse(json);
            byte first = (byte)customizationInfo.firstParent;
            byte second = (byte)customizationInfo.secondParent;
            float shape = (float)customizationInfo.shape;
            float skin = (float)customizationInfo.skin;
            byte comp = (byte)customizationInfo.component;
            byte drawable = (byte)customizationInfo.drawable;
            RAGE.Elements.Player.LocalPlayer.SetHeadBlendData(first, second, 0, first, second, 0, shape, skin, 0, true);
        }
    }
}