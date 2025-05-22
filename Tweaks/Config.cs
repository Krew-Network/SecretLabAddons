namespace Tweaks
{
    using System.ComponentModel;
    
    public class Config
    {
        [Description("Indicates whether debug messages should be shown.")]
        public bool Debug { get; set; } = false;

        [Description("Enables whether radio batteries should be infinite")]
        public bool InfiniteBattery { get; set; } = true;

        [Description("Enables whether Guards should spawn with adrenaline")]
        public bool GuardsWithAdrenaline { get; set; } = true;
    }
}