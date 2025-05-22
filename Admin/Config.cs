namespace Admin
{
    using System.ComponentModel;
    
    public class Config
    {
        [Description("Indicates whether debug messages should be shown.")]
        public bool Debug { get; set; } = false;
        
        // Following code is not my own, i do not claim ownership
        [Description("The number of seconds which a poll will be displayed on top of players' screens.")]
        public ushort PollTextDuration { get; set; } = 5;

        [Description("The number of seconds which polls should last for.")]
        public int PollDuration { get; set; } = 30;

        [Description("Message that will be broadcast when a poll starts.")]
        public string PollStartedBroadcast { get; set; } = "Polls: {message}\nType \".vote yes\" or \".vote no\" in the console to vote!";

        [Description("Message that will be broadcast when a poll Ends.")]
        public string PollEndedBroadcast { get; set; } = "The poll has ended! {numYes} voted yes and {numNo} voted no!";
    }
}