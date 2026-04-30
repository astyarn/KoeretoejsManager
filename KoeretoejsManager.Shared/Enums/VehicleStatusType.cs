using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KoeretoejsManager.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleStatusType
    {
        Available = 0,
        InUse = 1,
        Maintenance = 2,
        Decommissioned = 3
    }
}
