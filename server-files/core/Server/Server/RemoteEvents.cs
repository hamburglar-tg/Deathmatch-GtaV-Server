using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
public class RemoteEvents : Script
{
    [RemoteEvent("CLIENT:SERVER::REGISTER_BUTTON_CLICKED")]
    public async void OnCefRegisterButtonClicked(Player player, string username, string password, string email)
    {
        ulong socialclubid;
        socialclubid = NAPI.Player.GetPlayerSocialClubId(player);
        string selectQuery = "SELECT * FROM users WHERE username = @name";
        MySqlCommand selectCommand = new MySqlCommand(selectQuery);
        selectCommand.Parameters.AddWithValue("@name", username);
        DataTable tb = await MySQL.QueryReadAsync(selectCommand);

        string inserQuery = "INSERT INTO users_data (usrname) VALUES (@name)";
        MySqlCommand insetCommand = new MySqlCommand(inserQuery);
        insetCommand.Parameters.AddWithValue("@name", username);
        MySQL.Query(insetCommand);

        if (tb.Rows.Count > 0)
        {
            NAPI.Task.Run(() =>
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::REGISTER_USER", true);
            }, 1000);
            
        }
        else
        {
            
            string insertQuery = "INSERT INTO users (username, password, email, socialclubid) VALUES (@name, @password, @email, @socialclubid)";
            MySqlCommand insertCommand = new MySqlCommand(insertQuery);
            insertCommand.Parameters.AddWithValue("@name", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.AddWithValue("@socialclubid", socialclubid);
            MySQL.Query(insertCommand);
            NAPI.Task.Run(() =>
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::REGISTER_USER", false);
                NAPI.World.SetTime(23, 15, 0);
                player.Position = new Vector3(-1698.8102, -1093.2312, 13.152362);
                player.Rotation = new Vector3(0, 0, 47.452778);
                player.Dimension = player.Id;
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 21, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
                SetPersonCustomization(player, true,21, 0, 0.5f, 0.5f);
                player.SetData<string>("player_username", username);
            }, 1000);
            
        }
    }
    [RemoteEvent("CLIENT:SERVER::LOGIN_BUTTON_CLICKED")]
    public async void OnCefLoginButtonClicked(Player player, string username, string password)
    {
        
        string selectQuery = "SELECT * FROM users WHERE username = @name";
        MySqlCommand selectCommand = new MySqlCommand(selectQuery);
        selectCommand.Parameters.AddWithValue("@name", username);
        DataTable tb = await MySQL.QueryReadAsync(selectCommand);


        string slectQuery = "SELECT json FROM users_data WHERE usrname = @usrname";
        MySqlCommand slectCommand = new MySqlCommand(slectQuery);
        slectCommand.Parameters.AddWithValue("@usrname", username);
        DataTable tbb = await MySQL.QueryReadAsync(slectCommand);
        
    
        string selectQury = "SELECT gender FROM users WHERE username = @name";
        MySqlCommand selectommand = new MySqlCommand(selectQury);
        selectommand.Parameters.AddWithValue("@name", username);
        DataTable tbbb = await MySQL.QueryReadAsync(selectommand);
        string gender = tb.Rows[0].ItemArray[7].ToString();
        player.SetData<string>("player_gender", gender);
        
        

            

        
        if (tb.Rows.Count == 0)
        {
            NAPI.Util.ConsoleOutput("hello");
            NAPI.Task.Run(() =>
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::LOGIN_USER", true);
            },1000);
            
        
        }
        else
        {
            string outUsername = tb.Rows[0].ItemArray[1].ToString();
            string outPassword = tb.Rows[0].ItemArray[2].ToString();
            string outPersonName = tb.Rows[0].ItemArray[5].ToString();
            if (outPassword != password)
            {
                NAPI.Task.Run(() =>
                {
                   
                    NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::LOGIN_USER", true);
                    
                }, 1000);
            }
            else
            {
                if(outPersonName == null || outPersonName.Length == 0)
                {
                    NAPI.Task.Run(() =>
                    {
                        
                        NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::REGISTER_USER", false);
                        NAPI.World.SetTime(23, 15, 0);
                        player.Position = new Vector3(-1698.8102, -1093.2312, 13.152362);
                        player.Rotation = new Vector3(0, 0, 47.452778);
                        player.Dimension = player.Id;
                        SetPersonCustomization(player, true, 21, 0, 0.5f, 0.5f);
                        player.SetClothes(3, 15, 0);
                        player.SetClothes(4, 21, 0);
                        player.SetClothes(6, 34, 0);
                        player.SetClothes(8, 15, 0);
                        player.SetClothes(11, 15, 0);
                        
                    }, 1000);
                }
                else
                {
                    NAPI.Task.Run(() =>
                    {
                        
                        NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::LOGIN_USER", false);
                        string gender = player.GetData<string>("player_gender");
                        
                        bool gen;
                        if (gender == "male")
                        {
                            gen = true;
                        }
                        else
                        {
                            gen = false;
                        }
                        
                        
                        
                        string json = tbb.Rows[0].ItemArray[0].ToString();
                        dynamic customizationInfo = JObject.Parse(json);
                        if (string.IsNullOrEmpty(json)) return;
                        byte first = (byte)customizationInfo.firstParent;
                        byte second = (byte)customizationInfo.secondParent;
                        float shape = (float)customizationInfo.shape;
                        float skin = (float)customizationInfo.skin;
                        float noseWidth = (float)customizationInfo.noseWidth;
                        float noseHeight = (float)customizationInfo.noseHeight;
                        float noseLength = (float)customizationInfo.noseLength;
                        float noseBridge = (float)customizationInfo.noseBridge;
                        float noseTip = (float)customizationInfo.noseTip;
                        float noseBridgeShift = (float)customizationInfo.noseBridgeShift;
                        float browHeight = (float)customizationInfo.browHeight;
                        float browWidth = (float)customizationInfo.browWidth;
                        float cheekboneHeight = (float)customizationInfo.cheekboneHeight;
                        float cheekboneWidth = (float)customizationInfo.cheekboneWidth;
                        float cheeksWidth = (float)customizationInfo.cheeksWidth;
                        float Eyes = (float)customizationInfo.Eyes;
                        float Lips = (float)customizationInfo.Lips;
                        float jawWidth = (float)customizationInfo.jawWidth;
                        float jawHeight = (float)customizationInfo.jawHeight;
                        float chinLenght = (float)customizationInfo.chinLenght;
                        float chinPosition = (float)customizationInfo.chinPosition;
                        float chinWidth = (float)customizationInfo.chinWidth;
                        float chinShape = (float)customizationInfo.chinShape;
                        float neckWidth = (float)customizationInfo.neckWidth;
                        player.SetFaceFeature(0, noseWidth);
                        player.SetFaceFeature(1, noseHeight);
                        player.SetFaceFeature(2, noseLength);
                        player.SetFaceFeature(3, noseBridge);
                        player.SetFaceFeature(4, noseTip);
                        player.SetFaceFeature(5, noseBridgeShift);
                        player.SetFaceFeature(6, browHeight);
                        player.SetFaceFeature(7, browWidth);
                        player.SetFaceFeature(8, cheekboneHeight);
                        player.SetFaceFeature(9, cheekboneWidth);
                        player.SetFaceFeature(10, cheeksWidth);
                        player.SetFaceFeature(11, Eyes);
                        player.SetFaceFeature(12, Lips);
                        player.SetFaceFeature(13, jawWidth);
                        player.SetFaceFeature(14, jawHeight);
                        player.SetFaceFeature(15, chinLenght);
                        player.SetFaceFeature(16, chinPosition);
                        player.SetFaceFeature(17, chinWidth);
                        player.SetFaceFeature(18, chinShape);
                        player.SetFaceFeature(19, neckWidth);
                        SetPersonCustomization(player, gen, first, second, shape, skin);
                    }, 1000);
                }
            }
        }
    }
    [RemoteEvent("CLIENT:SERVER::PERSON_CREATE_BUTTON_CLICKED")]
    public void OnCefPersonCreateButtonClicked(Player player, string name, string age, string gender)
    {
        if (player.HasData("player_username"))
        {
            string username = player.GetData<string>("player_username");
            string updateQuery = "UPDATE users SET name = @name, age = @age, gender = @gender WHERE username = @username";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery);
            updateCommand.Parameters.AddWithValue("@name", name);
            updateCommand.Parameters.AddWithValue("@age", age);
            updateCommand.Parameters.AddWithValue("@gender", gender);
            updateCommand.Parameters.AddWithValue("@username", username);
            MySQL.Query(updateCommand);
            NAPI.Task.Run(() =>
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT::CREATE_PERSON");
            }, 1000);
        }
    }
    [RemoteEvent("CLIENT:SERVER::PERSON_CREATE_GENDER_BUTTON_CLICKED")]
    public void OnCefPersonCreateGenderMaleButtonClicked(Player player, string gender)
    {
        NAPI.Player.SetPlayerSkin(player, gender.ToLower() == "male" ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
        NAPI.Task.Run(() =>
        {
            if (gender.ToLower() == "male")
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 21, 0);
                player.SetClothes(6, 34, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }
            else
            {
                player.SetClothes(3, 15, 0);
                player.SetClothes(4, 15, 0);
                player.SetClothes(6, 35, 0);
                player.SetClothes(8, 15, 0);
                player.SetClothes(11, 15, 0);
            }
            NAPI.ClientEvent.TriggerClientEvent(player, "SERVER:CLIENT:UPDATE_SAVED_CUSTOMIZATION");
        }, 10);
    }
    [RemoteEvent("CLIENT:SERVER::PERSON_CREATE_UPDATE_CUSTOMIZATION")]
    public void OnCefPersonCreateUpdateCustomizaztion(Player player, string jsonString)
    {
        if (string.IsNullOrEmpty(jsonString)) return;
        dynamic customizationInfo = JObject.Parse(jsonString);
        byte first = (byte)customizationInfo.firstParent;
        byte second = (byte)customizationInfo.secondParent;
        float shape = (float)customizationInfo.shape;
        float skin = (float)customizationInfo.skin;
        byte comp = (byte)customizationInfo.component;
        byte drawable = (byte)customizationInfo.drawable;
        string username = player.GetData<string>("player_username");
        string updateQuery = "UPDATE users_data SET json = @json WHERE usrname = @useername";
        MySqlCommand updateCommand = new MySqlCommand(updateQuery);
        updateCommand.Parameters.AddWithValue("@useername", username);
        updateCommand.Parameters.AddWithValue("@json", jsonString);
        MySQL.Query(updateCommand);
        //player.SetClothes(comp, drawable, 0);
        //SetPersonCustomization(player, true, first, second, shape, skin);
    }
    private void SetPersonCustomization(Player player, bool gender, byte firstp, byte secondp, float shapeMi, float skinMi)
    {
        HeadBlend headBlend = new HeadBlend()
        {
            ShapeFirst = firstp,
            ShapeSecond = secondp,
            ShapeThird = 0,
            SkinFirst = firstp,
            SkinSecond = secondp,
            SkinThird = 0,
            ShapeMix = shapeMi,
            SkinMix = skinMi,
            ThirdMix = 0
        };
        float[] faceFeatures = new float[20]
        {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        };
        Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>();
        player.SetCustomization(gender, headBlend, byte.MinValue, byte.MinValue, byte.MinValue, faceFeatures, headOverlays, new Decoration[] { });
    }
}