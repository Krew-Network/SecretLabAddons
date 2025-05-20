namespace Tweaks
{
    using System.ComponentModel;
    
    public class Config
    {
        public bool IsEnabled { get; set; } = true;
        
        [Description("Indicates whether debug messages should be shown.")]
        public bool Debug { get; set; } = false;
        
    }
}