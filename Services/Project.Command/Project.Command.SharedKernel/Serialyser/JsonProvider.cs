using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Project.Command.SharedKernel.Serialyser
{
    public class JsonProvider : IJsonProvider
    {
        public string SerializeObject<TEvent>(TEvent domainEvent)
        {
            string serializedEvent = JsonConvert.SerializeObject(domainEvent, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return serializedEvent;
        }
    }
}
