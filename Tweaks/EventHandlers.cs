using MEC;

namespace Tweaks
{
    using LabApi.Events.CustomHandlers;
    using LabApi.Events.Arguments.PlayerEvents;
    using LabApi.Features.Console;
    
    internal class EventHandlers : CustomEventsHandler
    {
        
        /// <summary>
        /// Tweaks in this event: Making radio battery infinite
        /// </summary>
        /// <param name="ev"></param>
        public override void OnPlayerUsedRadio(PlayerUsedRadioEventArgs ev)
        {
            if (Plugin.Instance.Config.InfiniteBattery)
                ev.RadioItem.BatteryPercent = 100;
            base.OnPlayerUsedRadio(ev);
        }


        /// <summary>
        /// Tweaks in this event: Making guards spawn with adrenaline
        /// </summary>
        /// <param name="ev"></param>
        public override void OnPlayerSpawned(PlayerSpawnedEventArgs ev)
        {
            if (Plugin.Instance.Config.GuardsWithAdrenaline)
            {
                if (ev.Role.RoleName == "Facility Guard")
                {
                    Timing.CallDelayed(1f, () =>
                    {
                        ev.Player.AddItem(ItemType.Adrenaline);
                    });
                }
            }
            base.OnPlayerSpawned(ev);
        }
    }
}