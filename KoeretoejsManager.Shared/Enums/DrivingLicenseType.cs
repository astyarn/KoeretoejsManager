using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KoeretoejsManager.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DrivingLicenseType
    {
        Unknown = 0,    //In case of missing or invalid data
        B, 
        BE, 
        C, 
        C1, 
        CE, 
        C1E, 
        D, 
    }
}
