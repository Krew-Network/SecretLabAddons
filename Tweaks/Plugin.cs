namespace Tweaks
{
    using System;
    using LabApi.Events.CustomHandlers;
    using LabApi.Features;
    using LabApi.Loader.Features.Plugins.Enums;
    using LabApi.Loader.Features.Plugins;
    
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public override LoadPriority Priority { get; } = LoadPriority.Low;

        public override string Author { get; } = "Zombie";
        
        public override string Name { get; } = "Tweaks";

        public override string Description { get; } = "A plugin that tweaks the functionality of Secret Lab";

        public override Version Version { get; } = new Version(0, 0, 1);
        
        public override Version RequiredApiVersion { get; } = new Version(LabApiProperties.CompiledVersion);
        
        EventHandlers Events { get; } = new EventHandlers();
        
        public override void Enable()
        {
            Instance = this;
            LoadConfigs();
            CustomHandlersManager.RegisterEventsHandler(Events);
        }
        
        public override void Disable()
        {
            Instance = null;
            CustomHandlersManager.UnregisterEventsHandler(Events);
        }
    }
}