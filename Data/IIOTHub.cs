using System.Threading.Tasks;

namespace MCCC_App.Data
{
    public interface IIOTHub
    {
        Task<string> DeviceState(string deviceId);

        Task<string> DoorState(string deviceId);

        Task ToggleDoor(string deviceId, string toggleTo);
    }
}