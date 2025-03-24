using UnityEngine;
using Fusion;


// class này dùng để spawn pkayer vào game trong network
public class PlayerSpawer : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    // khi vào mạng thì tạo nhân vật cho người chơi
    public void PlayerJoined(PlayerRef player)
    {
        // kiểm tra xem người này có phải là người chơi đang chơi không
        if(player == Runner.LocalPlayer)
        {
            //tạo nhân vật ở vị trí (0, 1, 0)
            // gọi APU lấy thông tin Player
            var positon = new Vector3 (0, 2, 0 );
            // spawn nhân vật ở vị trí này
            Runner.Spawn(PlayerPrefab, positon, Quaternion.identity, Runner.LocalPlayer, (runner, obj) =>
            {
                var playersetup = obj.GetComponent<PlayerSetup>();
                if (playersetup != null) playersetup.SetupCamera();
            }
            );
        };    


    }
}
