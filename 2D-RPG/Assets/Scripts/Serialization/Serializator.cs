using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
namespace Serialization
{
    public static class Serializator
    {
        public static void Serializate(object data, string savePath)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(savePath, serializedData);
        }

        public static T Deserializate<T>(string savePath)
        {
            string serializatedData = File.ReadAllText(savePath);
            return JsonConvert.DeserializeObject<T>(serializatedData);
        }
    }
}