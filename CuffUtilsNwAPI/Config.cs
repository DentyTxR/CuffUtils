using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace CuffUtilsNwAPI
{
    public class Config
    {

        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug logs be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Can detain players get shot?")]
        public bool DetainPlayerTakeDmg { get; set; } = true;

        [Description("Blacklist of roletypes that cannot damage a detain player")]
        public List<RoleTypeId> BlacklistDetainDamageRole { get; set; } = new List<RoleTypeId>
        {
            RoleTypeId.Spectator
        };
    }
}