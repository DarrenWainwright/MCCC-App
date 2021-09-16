using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MCCC_App.Data
{

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DoorAction
    {
        public string MethodName {get;set;}
        public Payload Payload {get;set;}

        public DoorAction(){
            Payload = new Payload();
        }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Payload{
        public string Action {get;set;}
    }
}