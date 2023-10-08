using RAGE;

using Newtonsoft.Json.Linq;

using RAGE.Game;

public class CefEvents : Events.Script
{
    public CefEvents() 
    {
        Events.Add("CEF:CLIENT::REGISTER_BUTTON_CLICKED", OnCegRegisterButtonClicked);
        Events.Add("CEF:CLIENT::LOGIN_BUTTON_CLICKED", OnCefLoginButtonCLiked);
        Events.Add("CEF:CLIENT::PERSON_CREATE_BUTTON_CLICKED", OnCefPersonCreateButtonClicked);
        Events.Add("CEF:CLIENT::PERSON_CREATE_GENDER_BUTTON_CLICKED", OnPersonCreateGenderButtonClicked);
        Events.Add("CEF:CLIENT::PERSON_CREATE_UPDATE_CUSTOMIZATION", OnCefPersonCreateUpdateCustomization);
    }
    public void OnCegRegisterButtonClicked(object[] args)
    {
        string username = args[0].ToString();
        string password = args[1].ToString();
        string email = args[2].ToString();
        Events.CallRemote("CLIENT:SERVER::REGISTER_BUTTON_CLICKED", username, password, email);
    }
    public void OnCefLoginButtonCLiked(object[] args)
    {
        string username = args[0].ToString();
        string password = args[1].ToString();
        Events.CallRemote("CLIENT:SERVER::LOGIN_BUTTON_CLICKED", username, password);
    }
    public void OnCefPersonCreateButtonClicked(object[] args)
    {
        string name = args[0].ToString();
        string age = args[1].ToString();
        string gender = args[2].ToString();
        Events.CallRemote("CLIENT:SERVER::PERSON_CREATE_BUTTON_CLICKED", name, age, gender);
    }
    public void OnPersonCreateGenderButtonClicked(object[] args)
    {
        string gender = args[0].ToString();
        Events.CallRemote("CLIENT:SERVER::PERSON_CREATE_GENDER_BUTTON_CLICKED", gender);
    }
    public void OnCefPersonCreateUpdateCustomization(object[] args)
    {

        string jsonString = args[0].ToString();
        if (string.IsNullOrEmpty(jsonString)) return;
        dynamic customizationInfo = JObject.Parse(jsonString);
        byte first = (byte)customizationInfo.firstParent;
        byte second = (byte)customizationInfo.secondParent;
        float shape = (float)customizationInfo.shape;
        float skin = (float)customizationInfo.skin;
        byte comp = (byte)customizationInfo.component;
        byte drawable = (byte)customizationInfo.drawable;

        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(0, (float)customizationInfo.noseWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(1, (float)customizationInfo.noseHeight);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(2, (float)customizationInfo.noseLength);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(3, (float)customizationInfo.noseBridge);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(4, (float)customizationInfo.noseTip);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(5, (float)customizationInfo.noseBridgeShift);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(6, (float)customizationInfo.browHeight);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(7, (float)customizationInfo.browWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(8, (float)customizationInfo.cheekboneHeight);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(9, (float)customizationInfo.cheekboneWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(10, (float)customizationInfo.cheeksWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(11, (float)customizationInfo.Eyes);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(12, (float)customizationInfo.Lips);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(13, (float)customizationInfo.jawWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(14, (float)customizationInfo.jawHeight);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(15, (float)customizationInfo.chinLenght);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(16, (float)customizationInfo.chinPosition);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(17, (float)customizationInfo.chinWidth);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(18, (float)customizationInfo.chinShape);
        RAGE.Elements.Player.LocalPlayer.SetFaceFeature(19, (float)customizationInfo.neckWidth);
        RAGE.Elements.Player.LocalPlayer.SetComponentVariation(comp, drawable, 0,0);
        RAGE.Elements.Player.LocalPlayer.SetHeadBlendData(first, second, 0, first, second, 0, shape, skin, 0, true);
        RAGE.Elements.Player.LocalPlayer.SetData("CLIENT_CUSTOMIZATION_DATA", jsonString);
        Events.CallRemote("CLIENT:SERVER::PERSON_CREATE_UPDATE_CUSTOMIZATION", jsonString);
    }
}
