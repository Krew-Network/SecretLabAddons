namespace Admin
{
    using System;
    using LabApi.Events.CustomHandlers;
    using LabApi.Features;
    using LabApi.Loader.Features.Plugins;
    using LabApi.Loader.Features.Plugins.Enums;
    using Polls;
    using MEC;
    
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        
        public override LoadPriority Priority { get; } = LoadPriority.Low;

        public override string Author { get; } = "Zombie";
        
        public override string Name { get; } = "Admin";

        public override string Description { get; } = "A plugin for our admin tools of Secret Lab";

        public override Version Version { get; } = new Version(0, 0, 1);
        
        public override Version RequiredApiVersion { get; } = new Version(LabApiProperties.CompiledVersion);
        
        public EventHandlers Events { get; } = new EventHandlers();
        
        /// <summary>
        ///  Tracks the active poll running in the server
        /// </summary>
        public Poll ActivePoll;
        
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
            
            
            // Kills any active coroutines for polls
            if (ActivePoll == null)
            {
                Timing.KillCoroutines(new CoroutineHandle[]
                {
                    ActivePoll.ActiveCoro
                });
            }
        }
    }
}