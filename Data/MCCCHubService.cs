using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MCCC_App.Data
{
    public class MCCCHubService : IIOTHub
    {
        private readonly HttpClient httpClient;

        public MCCCHubService(IHttpClientFactory httpFactory){
            httpClient = httpFactory.CreateClient("IotHubClient");
        }

        public async Task<string> DeviceState(string deviceId){
            try
            {
                 var response = await httpClient.GetAsync($"devices/{deviceId}?api-version=2020-05-31-preview");
                 if (!response.IsSuccessStatusCode){
                     throw new InvalidOperationException(response.ReasonPhrase);
                 }
                 var json = await response.Content.ReadAsStringAsync();
                 return JObject.Parse(json)["connectionState"].ToString();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }


        public async Task<string> DoorState(string deviceId){
            try
            {
                var payload = new StringContent("{'methodName': 'GetDoorState', 'payload': '{}'}", System.Text.Encoding.UTF8, "application/json");
                 var response = await httpClient.PostAsync($"twins/{deviceId}/methods?api-version=2020-05-31-preview", payload);
                 if (!response.IsSuccessStatusCode){
                     throw new InvalidOperationException(response.ReasonPhrase);
                 }
                 
                 var json = await response.Content.ReadAsStringAsync();
                 return JObject.Parse(json)["payload"]["doorState"].ToString();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task ToggleDoor(string deviceId, string toggleTo){
            try
            {
                //  "{'methodName': 'DoorAction', 'payload': '{'action': '" + toggleTo + "'}'}"
                var doorAction = new DoorAction{
                    MethodName = "DoorAction",
                };
                doorAction.Payload.Action = toggleTo;
                var payload = new StringContent(JsonConvert.SerializeObject(doorAction), System.Text.Encoding.UTF8, "application/json");
                 var response = await httpClient.PostAsync($"twins/{deviceId}/methods?api-version=2020-05-31-preview", payload);
                 if (!response.IsSuccessStatusCode){
                     throw new InvalidOperationException(response.ReasonPhrase);
                 }
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }


        
    }
}