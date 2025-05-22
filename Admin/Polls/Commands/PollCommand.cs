namespace Admin.Polls.Commands
{
    using System;
    using CommandSystem;
    
    [CommandHandler(typeof (RemoteAdminCommandHandler))]
    [CommandHandler(typeof (ClientCommandHandler))]
    public class PollCommand : ICommand
    {
        public string Command { get; } = "poll";

        public string[] Aliases { get; } = new string[0];

        public string Description { get; } = "Starts a poll.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.Broadcasting))
            {
                response = "You do not have permission to use ths command!";
                return false;
            }
            if (Plugin.Instance.ActivePoll != null)
            {
                response = "There is an already active poll!";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "You must specify a message for the poll!";
                return false;
            }
            string name = "";
            foreach (string str in arguments)
                name = $"{name}{str} ";
            Plugin.Instance.ActivePoll = new Polls.Poll(name);
            response = "Succesfully created poll: " + name;
            return true;
        }
    }
}