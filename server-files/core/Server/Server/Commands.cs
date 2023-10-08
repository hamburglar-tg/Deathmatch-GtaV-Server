using GTANetworkAPI;

public class Commands : Script
{

    
    [Command("getpos")]
    public void Cmd_getpos(Player player)
    {
        Vector3 playerPosition = player.Position;
        NAPI.Util.ConsoleOutput($"{playerPosition.X} {playerPosition.Y} {playerPosition.Z}");
        Vector3 playerRotation = player.Rotation;
        NAPI.Util.ConsoleOutput($"{playerRotation.X} {playerRotation.Y} {playerRotation.Z}");
    }
    [Command("weapon")]
    public void WeaponCommand(Player sender, WeaponHash hash)
    {
        NAPI.Player.GivePlayerWeapon(sender, hash, 500);
    }
    [Command("addnpc")]
    public void Addnpc(Player player, PedHash pedHash)
    {
        Vector3 PlayerPos = NAPI.Entity.GetEntityPosition(player);
        Ped John = NAPI.Ped.CreatePed((uint)pedHash, new Vector3(PlayerPos.X + 1f, PlayerPos.Y + 1f, PlayerPos.Z + 1f), 5f, true, false, false, false, 0);
        
        
    }
    [Command("veh")]
    public static void CMD_createVehicle(Player player, VehicleHash vehicleHash, int color1, int color2, string platenumber)
    {

  
        Vector3 PlayerPos = NAPI.Entity.GetEntityPosition(player);
        Vehicle myveh1 = NAPI.Vehicle.CreateVehicle(vehicleHash, new Vector3(PlayerPos.X + 1f, PlayerPos.Y + 2f, PlayerPos.Z + 1f), 10f, color1, color2, platenumber);
        NAPI.Vehicle.SetVehicleNeonState(myveh1, true);
        NAPI.Vehicle.SetVehicleNeonColor(myveh1, 255, 0, 0);
        NAPI.Player.SetPlayerIntoVehicle(player, myveh1, 0);
        NAPI.Player.SetPlayerName(player, "BeastPlayerXYZ");
        NAPI.Chat.SendChatMessageToPlayer(player, $"Игрок: {player.Name} | Заспавнил авто: {vehicleHash}");

    }




}