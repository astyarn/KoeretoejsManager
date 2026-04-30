using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KoeretoejsManager.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRoleType
    {
        Employee = 0,
        Manager = 1,
        Admin = 2
    }
}
