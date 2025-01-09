using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

namespace CuffUtilsExiled
{
    public class Config : IConfig
    {

        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug logs be enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Can detain players get shot?")]
        public bool DetainPlayerTakeDmg { get; set; } = true;

        [Description("Can detain players get damaged by scps?")]
        public bool DetainPlayerTakeScpDmg { get; set; } = true;

        [Description("Can the cuffer damage the cuffed player?")]
        public bool CanCufferDamageCuffed { get; set; } = true;

        [Description("Blacklist of roletypes that cannot damage a detain player")]
        public List<RoleTypeId> BlacklistDetainDamageRole { get; set; } = new List<RoleTypeId>
        {
            RoleTypeId.Spectator,
        };

        [Description("Whitelist of roletypes that can damage cuffed players. THIS WILL BYPASS ALL CHECKS")]
        public List<RoleTypeId> WhitelistCuffDamageRole { get; set; } = new List<RoleTypeId>
        {
            RoleTypeId.Spectator,
        };

        [Description("Should detained players get uncuffed when they move too far away from cuffer?")]
        public bool EnableCuffRemoveOnDistance { get; set; } = false;

        [Description("How far the detained player should be from the detainer to get uncuffed")]
        public float CuffRemoveDistance { get; set; } = 10f;
    }
}