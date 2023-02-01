# CuffUtils W.I.P

### Multi-purpose plugin that creates many features around cuffing events to help moderation/gameplay changes
[![Github All Releases](https://img.shields.io/github/downloads/DentyTxR/CuffUtils/total.svg)]()

WIP, I have a few planned features for this plugin but I want more so please gib suggestions

### How do I download this?
  - Go here and download the latest release, https://github.com/DentyTxR/CuffUtils/releases

### Current Features
 - Disallow damage to detain players
 - Blacklist certain RoleTypes from damaging detain players
 - Remove cuffs when the detained player moves too far from the detainer (The best way to describe how `remove_cuffs_distance` is measured is by feet I would say? I would test it before using it on your main server)

### Default Config
```yml
# Whether or not the plugin is enabled.
is_enabled: true
# Should debug logs be enabled?
debug: false
# Can detain players get shot?
detain_player_take_dmg: true
# Blacklist of roletypes that cannot damage a detain player
blacklist_detain_damage_role:
- Spectator
- ClassD
- Scientist
# Whitelist of roletypes that can damage cuffed players. THIS WILL BYPASS ALL CHECKS
whitelist_cuff_damage_role:
- Tutorial
# Should detained players get uncuffed when they move too far away from cuffer?
remove_cuffs_distance_feature: false
# How far the detained player should be from the detainer to get uncuffed
remove_cuffs_distance: 10

```

### RoleTypes
- Scp173, ClassD, Spectator, Scp106, NtfSpecialist, Scp049, Scientist, Scp079, ChaosConscript, Scp096, Scp0492, NtfSergeant, NtfCaptain, NtfPrivate, Tutorial, FacilityGuard, Scp939, CustomRole, ChaosRifleman, ChaosRepressor, ChaosMarauder, Overwatch